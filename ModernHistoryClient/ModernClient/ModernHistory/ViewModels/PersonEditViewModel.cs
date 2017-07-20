using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;
using System.Linq;
// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Models;
using ModernHistory.Services;
using System.Windows.Forms;

namespace ModernHistory.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class PersonEditViewModel : ViewModelBase<PersonAddViewModel>
    {
        private IFamousePersonService personService;

        private IImageService imageService;

        private FamousPerson famousPerson = null;

        private string selectImg=null;

        private Boolean isMale = true;

        public Boolean IsMale
        {
            get { return isMale; }
            set
            {
                if (isMale != value)
                {
                    isMale = value;
                    NotifyPropertyChanged(p => p.IsMale);
                }
            }
        }

        private Boolean isFemale = false;

        public Boolean IsFemale
        {
            get { return isFemale; }
            set
            {
                if (isFemale != value)
                {
                    isFemale = value;
                    NotifyPropertyChanged(p => p.IsFemale);
                }
            }
        }

        public PersonEditViewModel(IFamousePersonService personService, IImageService imageService)
        {
            this.personService = personService;
            this.imageService = imageService;
            Initial();
        }

        public FamousPerson FamousPerson
        {
            get { return famousPerson; }
            set
            {
                if (famousPerson != value)
                {
                    famousPerson = value;
                    NotifyPropertyChanged(p => p.FamousPerson);
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
                FamousPerson.Gender = IsMale ? (byte)1 : (byte)2;
                FamousPerson.PersonType = CommonConstViewModel.Instance.FamousPersonTypes.Where(p => p.FamousPersonTypeId == FamousPerson.FamousPersonTypeId).FirstOrDefault();
                var dtoModel = DtoConvert.DtoConvertToModel.FamousePersonConvert(FamousPerson);
                dtoModel.PersonType = null;
                await personService.UpdateAsync(dtoModel);
                System.Windows.MessageBox.Show("修改成功");
                if (!string.IsNullOrEmpty(SelectImg))
                {
                    await imageService.UploadPersonImgAsync(FamousPerson.FamousPersonId, SelectImg);
                }
                ViewModelLocator.MapPageViewModelInstance.EdiSyncPerson(FamousPerson);
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
            IsMale = true;
            FamousPerson = ViewModelLocator.PersonsInfoViewModelInstance.SelectFamousePerson;
            if (FamousPerson == null)
            {
               // System.Windows.MessageBox.Show("尚未选择任何人员信息");
                return;
            }
            SelectImg = imageService.GetPersonImgUrl(FamousPerson.FamousPersonId);
        }
    }
}