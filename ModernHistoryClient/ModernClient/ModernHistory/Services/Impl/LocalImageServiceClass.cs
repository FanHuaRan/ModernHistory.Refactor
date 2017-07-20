using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services
{
    class LocalImageServiceClass : IImageService
    {
        private static string PERSON_PICTURE_ROOT =string.Format("{0}\\resources\\images\\persons",System.Environment.CurrentDirectory);

        private static string EVENT_PICTURE_ROOT =string.Format("{0}\\resources\\images\\events",System.Environment.CurrentDirectory);

        public Task UploadPersonImgAsync(int eventId, string pictureName)
        {
            return Task.Run(() =>
            {
                var fileName=string.Format("{0}\\{1}.jpg",PERSON_PICTURE_ROOT,eventId);
                try
                {
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    File.Copy(pictureName, fileName);
                }
                catch (Exception e)
                {

                }
               
            });
        }

        public Task UploadEventImgAsync(int personId, string pictureName)
        {
             return Task.Run(() =>
            {
                var fileName = string.Format("{0}\\{1}.jpg",EVENT_PICTURE_ROOT,personId);
                try
                {
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    File.Copy(pictureName, fileName);
                }
                catch (Exception e)
                {

                }
              
            });
        }


        public Task<System.Drawing.Image> DownLoadPersonImgAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<System.Drawing.Image> DownLoadEventImgAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public string GetPersonImgUrl(int personId)
        {
            var fileName=string.Format("{0}\\{1}.jpg", PERSON_PICTURE_ROOT, personId);
            return File.Exists(fileName) ? fileName : null;
        }

        public string GetEventImgUrl(int eventId)
        {
            var fileName=string.Format("{0}\\{1}.jpg", EVENT_PICTURE_ROOT, eventId);
            return File.Exists(fileName) ? fileName : null;
        }
    }
}
