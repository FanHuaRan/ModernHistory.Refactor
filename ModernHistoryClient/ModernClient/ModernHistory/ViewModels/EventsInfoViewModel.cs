using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Services;
using ModernHistory.Models;
using System.Threading.Tasks;

namespace ModernHistory.ViewModels
{
    public class EventsInfoViewModel : ViewModelBase<EventsInfoViewModel>
    {
        private IHistoryEventService historyEventService;

        private IImageService imgService;

        private ObservableCollection<HistoryEvent> historyEvents;

        private HistoryEvent selectHistoryEvent;

        public EventsInfoViewModel(IHistoryEventService historyEventService, IImageService imgService)
        {
            this.historyEventService = historyEventService;
            this.imgService = imgService;
            Task.Run(async () =>
            {
                //try
                //{
                //    var famousePersonsDto = await this.personService.FindAllAsync();
                //    FamousPersons = DtoConvertToModel.FamousePersonsConvert(famousePersonsDto);
                //}
                //catch (ApiErrorException e)
                //{
                //    MessageBox.Show(e.Message);
                //}
                //延迟3S执行
                await Task.Delay(1000);
                var mapPageViewModelInstance = ViewModelLocator.MapPageViewModelInstance;
                if (mapPageViewModelInstance.HistoryEvents != null)
                {
                    HistoryEvents = mapPageViewModelInstance.HistoryEvents;
                }
            });
        }

        public ObservableCollection<HistoryEvent> HistoryEvents
        {
            get
            {
                return historyEvents;
            }
            set
            {
                if (historyEvents != value)
                {
                    this.historyEvents = value;
                    NotifyPropertyChanged(P => P.HistoryEvents);
                }
            }
        }
        public HistoryEvent SelectHistoryEvent
        {
            get
            {
                return selectHistoryEvent;
            }
            set
            {
                if (selectHistoryEvent != value)
                {
                    this.selectHistoryEvent = value;
                    NotifyPropertyChanged(P => P.SelectHistoryEvent);
                }
            }
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet

        // TODO: Add methods that will be called by the view
        public async void DeleteAsync()
        {
            if (SelectHistoryEvent != null)
            {
                try
                {
                    await historyEventService.DeleteAsync(SelectHistoryEvent.HistoryEventId);
                    ViewModelLocator.MapPageViewModelInstance.DeleteSyncEvent(SelectHistoryEvent);
                    SelectHistoryEvent = null;
                    MessageBox.Show("删除成功");
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
            }
        }

        // TODO: Optionally add callback methods for async calls to the service agent
        
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}