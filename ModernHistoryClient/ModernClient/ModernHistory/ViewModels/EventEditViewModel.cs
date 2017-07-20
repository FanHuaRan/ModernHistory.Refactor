using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;
using System.Linq;
// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Services;
using ModernHistory.Models;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ModernHistory.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class EventEditViewModel : ViewModelBase<EventEditViewModel>
    {
        private IHistoryEventService historyEventSerivce;

        private IImageService imageService;

        private HistoryEvent famousPerson = null;

        private string selectImg=null;

        public EventEditViewModel(IHistoryEventService historyEventSerivce, IImageService imageService)
        {
            this.historyEventSerivce = historyEventSerivce;
            this.imageService = imageService;
            Initial();
        }

        public HistoryEvent HistoryEvent
        {
            get { return famousPerson; }
            set
            {
                if (famousPerson != value)
                {
                    famousPerson = value;
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


        public async void UpdateAsync()
        {
            try
            {
                HistoryEvent.EventType=CommonConstViewModel.Instance.HistoryEventTypes.Where(p=>p.HistoryEventTypeId==HistoryEvent.HistoryEventTypeId).FirstOrDefault();
                var dtoModel = DtoConvert.DtoConvertToModel.HistoryEventConvert(HistoryEvent);
                await historyEventSerivce.UpdateAsync(dtoModel);
                System.Windows.MessageBox.Show("修改成功");
                if (!string.IsNullOrEmpty(SelectImg))
                {
                    await imageService.UploadEventImgAsync(HistoryEvent.HistoryEventId, SelectImg);
                }
                ViewModelLocator.MapPageViewModelInstance.EdiSyncEvent(HistoryEvent);
                Initial();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }
        public void ChooseImage()
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "*.jpg|*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.SelectImg = openFileDialog.FileName;
            }
        }

        public void Initial()
        {
            HistoryEvent = ViewModelLocator.EventsInfoViewModel.SelectHistoryEvent;
            if (HistoryEvent == null)
            {
               // System.Windows.MessageBox.Show("尚未选择任何人员信息");
                return;
            }
            SelectImg = imageService.GetPersonImgUrl(HistoryEvent.HistoryEventId);
        }
    }
}