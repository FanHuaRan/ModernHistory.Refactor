using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Services;
using ModernHistory.Models;
using ModernHistory.DtoConvert;
using System.Threading.Tasks;
using ModernHistory.Exceptions;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Controls;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Layers;
using System.Linq;
using System.Windows.Input;
using System.Windows.Controls;
using Esri.ArcGISRuntime.Data;
using ModernHistory.Gloabl;
using System.Collections.Generic;
using ModernHistory.Views.Dialogs;
using ModernHistory.Views.Event;
namespace ModernHistory.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class MapPageViewModel : ViewModelBase<MapPageViewModel>
    {
        #region tip显示控制区
        private Graphic personTipGraphic;

        public Graphic PersonTipGraphic
        {
            get { return personTipGraphic; }
            set
            {
                if (personTipGraphic != value)
                {
                    personTipGraphic = value;
                    NotifyPropertyChanged(p => p.PersonTipGraphic);
                }
            }
        }

        private Visibility personTipVisibility;

        public Visibility PersonTipVisibility
        {
            get { return personTipVisibility; }
            set
            {
                if (personTipVisibility != value)
                {
                    personTipVisibility = value;
                    NotifyPropertyChanged(p => p.PersonTipVisibility);
                }
            }
        }

        private bool _isHitTesting;


        private Graphic eventTipGraphic;

        public Graphic EventTipGraphic
        {
            get { return eventTipGraphic; }
            set
            {
                if (eventTipGraphic != value)
                {
                    eventTipGraphic = value;
                    NotifyPropertyChanged(p => p.EventTipGraphic);
                }
            }
        }

        private Visibility eventTipVisibility;

        public Visibility EventTipVisibility
        {
            get { return eventTipVisibility; }
            set
            {
                if (eventTipVisibility != value)
                {
                    eventTipVisibility = value;
                    NotifyPropertyChanged(p => p.EventTipVisibility);
                }
            }
        }

        public async void MyMapView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isHitTesting)
            {
                return;
            }
            try
            {
                _isHitTesting = true;
                System.Windows.Point screenPoint = e.GetPosition(mainMapView);
                PersonTipGraphic = await personsLayers.HitTestAsync(mainMapView, screenPoint);
                if (PersonTipGraphic != null)
                {
                    PersonTipVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    PersonTipVisibility = System.Windows.Visibility.Collapsed;
                }
                EventTipGraphic = await eventsLayer.HitTestAsync(mainMapView, screenPoint);
                if (EventTipGraphic != null)
                {
                    EventTipVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    EventTipVisibility = System.Windows.Visibility.Collapsed;
                }
            }
            catch
            {
                PersonTipVisibility = System.Windows.Visibility.Collapsed;
                EventTipVisibility = System.Windows.Visibility.Collapsed;
            }
            finally
            {
                _isHitTesting = false;
            }
        }
        #endregion

        /// <summary>
        /// 地图操作类型
        /// </summary>
        private MapOperationType mapOperationType = MapOperationType.None;

        //名人搜索模型
        private PersonSearchModel personSearhModel = new PersonSearchModel();

        public PersonSearchModel PersonSearhModel
        {
            get { return personSearhModel; }
            set
            {
                if (personSearhModel != value)
                {
                    personSearhModel = value;
                    NotifyPropertyChanged(p => p.PersonSearhModel);
                }
            }
        }

        //事件搜索模型
        private EventSearchModel eventSearhModel = new EventSearchModel();

        public EventSearchModel EventSearhModel
        {
            get { return eventSearhModel; }
            set
            {
                if (eventSearhModel != value)
                {
                    eventSearhModel = value;
                    NotifyPropertyChanged(p => p.EventSearhModel);
                }
            }
        }

        private ObservableCollection<FamousPerson> selectFamousPersons;

        public ObservableCollection<FamousPerson> SelectFamousPersons
        {
            get { return selectFamousPersons; }
            set
            {
                if (selectFamousPersons != value)
                {
                    selectFamousPersons = value;
                    NotifyPropertyChanged(p => p.SelectFamousPersons);
                }
            }
        }

        private ObservableCollection<HistoryEvent> selectHistoryEvents;

        public ObservableCollection<HistoryEvent> SelectHistoryEvents
        {
            get { return selectHistoryEvents; }
            set
            {
                if (selectHistoryEvents != value)
                {
                    selectHistoryEvents = value;
                    NotifyPropertyChanged(p => p.SelectHistoryEvents);
                }
            }
        }

        //主地图
        private MapView mainMapView = null;
        //鹰眼图
        private MapView overviewMap = null;
        //人员图层
        private GraphicsLayer personsLayers = null;
        //事件图层
        private GraphicsLayer eventsLayer = null;
        //人员marker
        private PictureMarkerSymbol personSymbol = new PictureMarkerSymbol()
        {
           // Opacity = MapMarkerConfig.PERSOM_MARKER_OPACITY,
            Height = MapMarkerConfig.PERSON_MARKER_SIZE,
            Width = MapMarkerConfig.PERSON_MARKER_SIZE,
        };
        //事件marker
        private PictureMarkerSymbol eventSymbol = new PictureMarkerSymbol()
        {
           // Opacity = MapMarkerConfig.EVENT_MARKER_OPACITY,
            Height = MapMarkerConfig.EVENT_MARKER_SIZE,
            Width = MapMarkerConfig.EVENT_MARKER_SIZE,
        };
        #region 鹰眼控制区
        #region Extent 暂时没用
            private Envelope extent = null;
            public Envelope Extent
            {
                get
                {
                    return extent;
                }
                set
                {
                    if (extent != value)
                    {
                        extent = value;
                        NotifyPropertyChanged(p => p.Extent);
                    }
                }
            }        
            #endregion
        //鹰眼图加载完毕
        /// <summary>
        /// 鹰眼图层加载完毕 后进入等待画矩形状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OverviewMap_LayerLoaded(object sender, LayerLoadedEventArgs e)
        {
            if (mainMapView == null)
            {
                overviewMap = sender as MapView;
            }
            await AddSingleGraphicAsync();
        }
        /// <summary>
        /// 一直添加鹰眼图框
        /// </summary>
        /// <returns></returns>
        private async Task AddSingleGraphicAsync()
        {
            try
            {
                await mainMapView.LayersLoadedAsync();
                var graphicsOverlay = overviewMap.GraphicsOverlays["overviewOverlay"];
                var symbol = GetGloabelResorce("RedFillSymbol") as Symbol;
                //  Symbol symbol = symbol = layoutGrid.Resources["RedFillSymbol"] as Symbol;
                while (true)
                {
                    var geometry = await overviewMap.Editor.RequestShapeAsync(DrawShape.Rectangle, symbol);
                    graphicsOverlay.Graphics.Clear();
                    var graphic = new Graphic(geometry, symbol);
                    graphicsOverlay.Graphics.Add(graphic);
                    var viewpointExtent = geometry.Extent;
                    await mainMapView.SetViewAsync(viewpointExtent);
                }
            }
            catch (TaskCanceledException)
            {
                // Ignore cancellations from selecting new shape type
            }
            catch (Exception ex)
            { }
            await AddSingleGraphicAsync();//递归调用 防止出错
        }
       
        /// <summary>
        /// 主图范围变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void MyMapView_ExtentChanged(object sender, System.EventArgs e)
        {
            var graphicsOverlay = overviewMap.GraphicsOverlays["overviewOverlay"];
            Graphic g = graphicsOverlay.Graphics.FirstOrDefault();
            if (g == null) //first time
            {
                g = new Graphic();
                graphicsOverlay.Graphics.Add(g);
            }
            var currentViewpoint = mainMapView.GetCurrentViewpoint(ViewpointType.BoundingGeometry);
            var viewpointExtent = currentViewpoint.TargetGeometry.Extent;
            g.Geometry = viewpointExtent;
            await overviewMap.SetViewAsync(viewpointExtent.GetCenter(), mainMapView.Scale * 15);
        }
        #endregion
        
        private IFamousePersonService personService;
        private IHistoryEventService historyEventService;
        private IImageService imgService;

        private ObservableCollection<FamousPerson> famousPersons;

        public ObservableCollection<FamousPerson> FamousPersons
        {
            get
            {
                return famousPersons;
            }
            set
            {
                if (famousPersons != value)
                {
                    this.famousPersons = value;
                    NotifyPropertyChanged(P => P.FamousPersons);
                }
            }
        }

        private ObservableCollection<HistoryEvent> historyEvents;

        public ObservableCollection<HistoryEvent> HistoryEvents
        {
            get { return historyEvents; }
            set
            {
                if (historyEvents != value)
                {
                    this.historyEvents = value;
                    NotifyPropertyChanged(P => P.FamousPersons);
                }
            }
        }

        public MapPageViewModel(IFamousePersonService personService, IHistoryEventService historyEventService, IImageService imgService)
        {
            this.personService = personService;
            this.historyEventService = historyEventService;
            this.imgService = imgService;
            Task.Run(async () =>
            {
                try
                {
                    var famousePersonsDto = await this.personService.FindAllAsync();
                    FamousPersons = DtoConvertToModel.FamousePersonsConvert(famousePersonsDto);
                    var eventsDto = await this.historyEventService.FindAllAsync();
                    HistoryEvents = DtoConvertToModel.HistoryEventsConvert(eventsDto);
                }
                catch (ApiErrorException e)
                {
                    MessageBox.Show(e.Message);
                }
               await personSymbol.SetSourceAsync(new Uri(MapMarkerConfig.PERSON_MARKER));
               await eventSymbol.SetSourceAsync(new Uri(MapMarkerConfig.EVENT_MARKER));
                if (FamousPersons != null)
                {
                    foreach (var value in FamousPersons)
                    {
                        personsLayers.Dispatcher.Invoke(() =>
                        {
                            //personsLayers.Graphics.Add(new Graphic(new MapPoint(-7000000, 3900000), personSymbol));
                            AddPersonGraphic(value);
                        });
                    }
                }
                if (HistoryEvents != null)
                {
                    foreach (var value in HistoryEvents)
                    {
                       // eventsLayer.Graphics.Add(new Graphic(new MapPoint(-7000000, 4000000), (Symbol)GetGloabelResorce("RedMarkerSymbolCircle")));
                        AddEventGraphic(value);
                    }
                }
            });
        }

        /// <summary>
        /// 异步查询名人信息
        /// </summary>
        public async void SearchPersonAsync()
        {
            var contions=await GetSearchPersonCondtionsAsync();
            if (contions.Count() == 0)
            {
                return;
            }
            bool isFirst = true;
            IEnumerable<FamousPerson> tmpQuery=null;
            foreach(var contion in contions)
            {
                if (isFirst)
                {
                    tmpQuery = FamousPersons.Where(contion);
                    isFirst = false;
                }
                else
                {
                    tmpQuery = tmpQuery.Where(contion);
                }
            }
            SelectFamousPersons = new ObservableCollection<FamousPerson>(tmpQuery);
            ShowSelectFamouses();
        }
        /// <summary>
        /// 获取名人查询条件
        /// </summary>
        /// <returns></returns>
        public Task<List<Func<FamousPerson,bool>>> GetSearchPersonCondtionsAsync()
        {
            return Task.Run<List<Func<FamousPerson, bool>>>(() =>
            {
                var condtions = new List<Func<FamousPerson, bool>>();
                if (!string.IsNullOrEmpty(personSearhModel.PersonName))
                {
                    condtions.Add(p => p.PersonName == personSearhModel.PersonName);
                }
                if (!string.IsNullOrEmpty(personSearhModel.Province))
                {
                    condtions.Add(p => p.Province == personSearhModel.Province);
                }
                if (!string.IsNullOrEmpty(personSearhModel.Nation))
                {
                    condtions.Add(p => p.Nation == personSearhModel.Nation);
                }
                if (personSearhModel.FamousPersonTypeId != null)
                {
                    condtions.Add(p => p.FamousPersonId == personSearhModel.FamousPersonTypeId);
                }
                return condtions;
            });
        }

        /// <summary>
        /// 异步查询事件信息
        /// </summary>
        public async void SearchEventAsync()
        {
            var contions = await GetSearchEventCondtionsAsync();
            if (contions.Count() == 0)
            {
                return;
            }
            IEnumerable<HistoryEvent> tmpQuery = null;
            bool isFirst = true;
            foreach (var contion in contions)
            {
                if (isFirst)
                {
                    tmpQuery = HistoryEvents.Where(contion);
                    isFirst = false;
                }
                else
                {
                    tmpQuery = tmpQuery.Where(contion);
                }
            }
            SelectHistoryEvents = new ObservableCollection<HistoryEvent>(tmpQuery);
            ShowSelectEvents();
        }
        /// <summary>
        /// 获取事件查询条件
        /// </summary>
        /// <returns></returns>
        public Task<List<Func<HistoryEvent, bool>>> GetSearchEventCondtionsAsync()
        {
            return Task.Run<List<Func<HistoryEvent, bool>>>(() =>
            {
                var condtions = new List<Func<HistoryEvent, bool>>();
                if (!string.IsNullOrEmpty(eventSearhModel.Title))
                {
                    condtions.Add(p => p.Title == eventSearhModel.Title);
                }
                if (!string.IsNullOrEmpty(eventSearhModel.Province))
                {
                    condtions.Add(p => p.Province == eventSearhModel.Province);
                }
                if (eventSearhModel.MinOccurDate!=null)
                {
                    condtions.Add(p => p.OccurDate == eventSearhModel.MinOccurDate);
                }
                if (eventSearhModel.HistoryEventTypeId != null)
                {
                    condtions.Add(p => p.HistoryEventTypeId == eventSearhModel.HistoryEventTypeId);
                }
                return condtions;
            });
        }



        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet

        // TODO: Add methods that will be called by the view

        // TODO: Optionally add callback methods for async calls to the service agent
        
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
        /// <summary>
        /// 界面load事件
        /// </summary>
        public ICommand MapPageLoadedCommand
        {
            get
            {
                return new DelegateCommand<Grid>(mapGrid =>
                {
                    if (mainMapView == null)
                    {
                        mainMapView = mapGrid.Children[0] as MapView;
                        personsLayers = mainMapView.Map.Layers
                                                    .Where(p => p.ID == "personsLayer")
                                                    .FirstOrDefault() 
                                                    as GraphicsLayer;
                        eventsLayer = mainMapView.Map.Layers
                                                   .Where(p => p.ID == "eventsLayer")
                                                   .FirstOrDefault()
                                                   as GraphicsLayer;
                    }
                    if (overviewMap == null)
                    {
                        var border = mapGrid.Children[1] as Border;
                        overviewMap = border.Child as MapView;
                    }
                });
            }
        }
        /// <summary>
        /// 获取全局资源
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetGloabelResorce(string key)
        {
            return System.Windows.Application.Current.Resources[key];
        }

        public void MapView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point screenPoint = e.GetPosition(mainMapView);
            MapPoint mapPoint = mainMapView.ScreenToLocation(screenPoint);
            if (mainMapView.WrapAround)
            {
                mapPoint = GeometryEngine.NormalizeCentralMeridian(mapPoint) as MapPoint;
            }
            switch (mapOperationType)
            {
                case MapOperationType.AddPerson:
                    var personAddDialogViewModel = new PersonAddDialogViewModel(personService, imgService);
                    personAddDialogViewModel.FamousPerson.BornX = mapPoint.X;
                    personAddDialogViewModel.FamousPerson.BornY = mapPoint.Y;
                    new PersonAddDialog(personAddDialogViewModel).ShowDialog();
                    break;
                case MapOperationType.AddEvent:
                    var eventAddDialogViewModel = new EventAddDialogViewModel(historyEventService, imgService);
                    eventAddDialogViewModel.HistoryEvent.OccurX = mapPoint.X;
                    eventAddDialogViewModel.HistoryEvent.OccurY = mapPoint.Y;
                    new EventAddDialog(eventAddDialogViewModel).ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public void InsertPerson()
        {
            if (mapOperationType != MapOperationType.AddPerson)
            {
                mapOperationType = MapOperationType.AddPerson;
            }
            else
            {
                mapOperationType = MapOperationType.None;
            }
        }
        public async void QueryPerson()
        {
            //if (mapOperationType != MapOperationType.QueryPerson)
            //{
                mapOperationType = MapOperationType.QueryPerson;
                var mapRect = await mainMapView.Editor.RequestShapeAsync(DrawShape.Envelope) as Envelope;
                personsLayers.ClearSelection();
                eventsLayer.ClearSelection(); 
                var winRect = new Rect(mainMapView.LocationToScreen(new MapPoint(mapRect.XMin, mapRect.YMax, mainMapView.SpatialReference)), mainMapView.LocationToScreen(new MapPoint(mapRect.XMax, mapRect.YMin, mainMapView.SpatialReference)));
                var graphics = await personsLayers.HitTestAsync(mainMapView, winRect, 1000);
                ShowSelectFamousesByGraphic(graphics);
                mapOperationType = MapOperationType.None;
            //}
            //else
            //{
            //    mapOperationType = MapOperationType.None;
            //    personsLayers.ClearSelection();
            //}
        }
        public void InsertEvent()
        {
            if (mapOperationType != MapOperationType.AddEvent)
            {
                mapOperationType = MapOperationType.AddEvent;
            }
            else
            {
                mapOperationType = MapOperationType.None;
            }
        }
        public async void QueryEvent()
        {
            //if (mapOperationType != MapOperationType.QueryEvent)
            //{
            mapOperationType = MapOperationType.QueryEvent;
            var mapRect = await mainMapView.Editor.RequestShapeAsync(DrawShape.Envelope) as Envelope;
            personsLayers.ClearSelection();
            eventsLayer.ClearSelection();
            var winRect = new Rect(mainMapView.LocationToScreen(new MapPoint(mapRect.XMin, mapRect.YMax, mainMapView.SpatialReference)),mainMapView.LocationToScreen(new MapPoint(mapRect.XMax, mapRect.YMin, mainMapView.SpatialReference)));
            var graphics = await eventsLayer.HitTestAsync(mainMapView, winRect, 1000);
            ShowSelectEventsByGraphic(graphics);
            mapOperationType = MapOperationType.None;
            // }
            // else
            // {
            //    mapOperationType = MapOperationType.None;
            // }
        }
        #region 数据同步区
        public void AddSyncPerson(FamousPerson famousePerson)
        {
            this.FamousPersons.Add(famousePerson);
            //同步Graphic
            AddPersonGraphic(famousePerson);
        }
        
        public void EdiSyncPerson(FamousPerson famouserPerson)
        {
            //同步Graphic
            EditPersonGraphic(famouserPerson);
        }
        public void DeleteSyncPerson(FamousPerson famousePerson)
        {
            //删除
            FamousPersons.Remove(famousePerson);
            //同步Graphic
            DeletePersonGraphic(famousePerson);
        }
        public void AddSyncEvent(HistoryEvent historyEvent)
        {
            historyEvents.Add(historyEvent);
            AddEventGraphic(historyEvent);
        }
        public void EdiSyncEvent(HistoryEvent historyEvent)
        {
            EditEventGraphic(historyEvent);
        }
        public void DeleteSyncEvent(HistoryEvent historyEvent)
        {
            //删除
            historyEvents.Remove(historyEvent);
            //同步Graphic
            DeleteEventGraphic(historyEvent);
        }
        private void AddPersonGraphic(FamousPerson person)
        {
            var point = new MapPoint(person.BornX, person.BornY);
            var graphic = new Graphic(point,(Symbol)GetGloabelResorce("RedMarkerSymbolCircle"));
            graphic.Attributes["PersonId"]=person.FamousPersonId;
            graphic.Attributes["PersonName"] = person.PersonName;
            graphic.Attributes["Place"] = person.BornPlace;
            graphic.Attributes["BornDate"] = person.BornDate;
            personsLayers.Dispatcher.Invoke(() =>
            {
                personsLayers.Graphics.Add(graphic);
            });
        }
         private void EditPersonGraphic(FamousPerson person)
        {
            var point = new MapPoint(person.BornX, person.BornY);
          //  var graphic = new Graphic(point,(Symbol)GetGloabelResorce("RedMarkerSymbolCircle");
           var graphic=personsLayers.Graphics.Where(p=>((int)p.Attributes["PersonId"])==person.FamousPersonId).FirstOrDefault();
           if (graphic != null)
           {
               graphic.Geometry = new MapPoint(person.BornX, person.BornY);
           }
        }
         private void DeletePersonGraphic(FamousPerson person)
         {
             var point = new MapPoint(person.BornX, person.BornY);
             //  var graphic = new Graphic(point,(Symbol)GetGloabelResorce("RedMarkerSymbolCircle");
             var graphic = personsLayers.Graphics.Where(p => ((int)p.Attributes["PersonId"]) == person.FamousPersonId).FirstOrDefault();
             if (graphic != null)
             {
                 personsLayers.Graphics.Remove(graphic);
             }
         }
         private void AddEventGraphic(HistoryEvent historyEvent)
        {
            var point = new MapPoint(historyEvent.OccurX, historyEvent.OccurY);
            var graphic = new Graphic(point, (Symbol)GetGloabelResorce("BoolueMarkerSymbolDiamond"));
            graphic.Attributes["EventId"]=historyEvent.HistoryEventId;
            graphic.Attributes["Title"] = historyEvent.Title;
            graphic.Attributes["Place"] = historyEvent.Place;
            graphic.Attributes["OccurDate"] = historyEvent.OccurDate;
            graphic.Attributes["Detail"] = historyEvent.Detail;
            eventsLayer.Dispatcher.Invoke(() => eventsLayer.Graphics.Add(graphic));
        }
         private void EditEventGraphic(HistoryEvent historyEvent)
         {
             var point = new MapPoint(historyEvent.OccurX, historyEvent.OccurY);
             //  var graphic = new Graphic(point,(Symbol)GetGloabelResorce("RedMarkerSymbolCircle");
             var graphic = eventsLayer.Graphics.Where(p => ((int)p.Attributes["EventId"]) == historyEvent.HistoryEventId).FirstOrDefault();
             if (graphic != null)
             {
                 graphic.Geometry = new MapPoint(historyEvent.OccurX, historyEvent.OccurY);
             }
         }
         private void DeleteEventGraphic(HistoryEvent historyEvent)
         {
             var point = new MapPoint(historyEvent.OccurX, historyEvent.OccurY);
             //  var graphic = new Graphic(point,(Symbol)GetGloabelResorce("RedMarkerSymbolCircle");
             var graphic = eventsLayer.Graphics.Where(p => ((int)p.Attributes["EventId"]) == historyEvent.HistoryEventId).FirstOrDefault();
             if (graphic != null)
             {
                 eventsLayer.Graphics.Remove(graphic);
             }
         }
        #endregion
         private void ShowSelectFamouses()
         {
             var grahics = personsLayers.Graphics.Where(g =>
             {
                 var personId = (int)g.Attributes["PersonId"];
                 return SelectFamousPersons.Where(p => p.FamousPersonId == personId).Count() > 0;
             });
             foreach (var v in grahics)
             {
                 v.IsSelected = true;
             }
             new SelectPersonsDialog().ShowDialog();
         }
         private void ShowSelectFamousesByGraphic(IEnumerable<Graphic> graphics)
         {
             SelectFamousPersons =new ObservableCollection<FamousPerson>(FamousPersons.Where(p =>
             {
                 return graphics.Where(g => (int)g.Attributes["PersonId"] == p.FamousPersonId).Count() > 0;
             }));
             foreach (var graphic in graphics)
             {
                 graphic.IsSelected = true;
             }
             new SelectPersonsDialog().ShowDialog();
         }
         private void ShowSelectEvents()
         {
             var grahics = eventsLayer.Graphics.Where(g =>
             {
                 var eventId = (int)g.Attributes["EventId"];
                 return SelectHistoryEvents.Where(p => p.HistoryEventId == eventId).Count() > 0;
             });
             foreach (var v in grahics)
             {
                 v.IsSelected = true;
             }
             new SelectEventsDialog().ShowDialog();
         }
         private void ShowSelectEventsByGraphic(IEnumerable<Graphic> graphics)
         {
             SelectHistoryEvents = new ObservableCollection<HistoryEvent>(HistoryEvents.Where(p =>
             {
                 return graphics.Where(g => (int)g.Attributes["EventId"] == p.HistoryEventId).Count() > 0;
             }));
             foreach (var graphic in graphics)
             {
                 graphic.IsSelected = true;
             }
             new SelectEventsDialog().ShowDialog();
         }
    }
}