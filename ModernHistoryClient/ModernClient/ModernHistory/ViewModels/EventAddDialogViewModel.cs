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
using FirstFloor.ModernUI.Windows.Controls;

namespace ModernHistory.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class EventAddDialogViewModel : ViewModelBase<EventAddViewModel>
    {
        private IHistoryEventService historyEventService;

        private IImageService imageService;

        private HistoryEvent historyEvent = new HistoryEvent()
        {
            OccurDate = DateTime.Parse("1900/01/01")
        };

        private string selectImg=null;

        public EventAddDialogViewModel(IHistoryEventService historyEventService, IImageService imageService)
        {
            this.historyEventService = historyEventService;
            this.imageService = imageService;
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
                if(!string.IsNullOrEmpty(SelectImg)){
                    await imageService.UploadEventImgAsync(result.HistoryEventId, SelectImg);
                }
                HistoryEvent.HistoryEventId = result.HistoryEventId;
                ViewModelLocator.MapPageViewModelInstance.AddSyncEvent(HistoryEvent);
                Dialog.Close();
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

        /// <summary>
        /// 窗体。。。便于回调，为了简单
        /// </summary>
        public ModernDialog Dialog { get; set; }
        public void Cancel()
        {
            Dialog.Close();
        }
    }
}