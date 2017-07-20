using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;
using System.Linq;
// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Services;
using ModernHistory.Models;
using System.Windows.Forms;

namespace ModernHistory.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class EventAddViewModel : ViewModelBase<EventAddViewModel>
    {
         private IHistoryEventService historyEventService;

        private IImageService imageService;

        private HistoryEvent historyEvent = new HistoryEvent();

        private string selectImg=null;

        public EventAddViewModel(IHistoryEventService historyEventService, IImageService imageService)
        {
            this.historyEventService = historyEventService;
            this.imageService = imageService;
            Initial();
        }

        public HistoryEvent HistoryEvent
        {
            get { return historyEvent; }
            set
            {
                if (historyEvent != value)
                {
                    historyEvent = value;
                    NotifyPropertyChanged(p => p.HistoryEvent);
                }
            }
        }
        public string SelectImg
        {
            get { return selectImg; }
            set
            {
                if (selectImg != value)
                {
                    selectImg = value;
                    NotifyPropertyChanged(p => p.SelectImg);
                }
            }
        }


        public async void SaveAsync()
        {
            try
            {
                HistoryEvent.EventType = CommonConstViewModel.Instance.HistoryEventTypes.Where(p => p.HistoryEventTypeId == HistoryEvent.HistoryEventTypeId).FirstOrDefault();
                var result=await historyEventService.SaveAsync(DtoConvert.DtoConvertToModel.HistoryEventConvert(HistoryEvent));
                System.Windows.MessageBox.Show("保存成功");
                HistoryEvent.HistoryEventId = result.HistoryEventId;
                if(!string.IsNullOrEmpty(SelectImg)){
                    await imageService.UploadEventImgAsync(result.HistoryEventId, SelectImg);
                }
                ViewModelLocator.MapPageViewModelInstance.AddSyncEvent(HistoryEvent);
                Initial();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        public void ChooseImage()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.jpg|*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.SelectImg = openFileDialog.FileName;
            }
        }

        public void Initial()
        {
            SelectImg = null;
            HistoryEvent = new HistoryEvent();
        }
    }
}