using Firebase.Storage;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewEuroMatchManagerment.Helper
{
    public class ImgUpload
    {
        private readonly FirebaseStorage _firebaseStorage;
        private readonly FirebaseEntities _firebaseEntities;
        private readonly string _bucketName;

        public ImgUpload(FirebaseEntities firebaseEntities)
        {
            _firebaseEntities = firebaseEntities;
            _firebaseStorage = new FirebaseStorage(_firebaseEntities.StorageBucket, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(_firebaseEntities.ApiKey)
            });
            _bucketName = _firebaseEntities.StorageBucket;
        }

        public async Task<string> UploadFileImg(string filePath)
        {
            try
            {
                string objectName = Path.GetFileName(filePath);
                using (var fileStream = File.OpenRead(filePath))
                {
                    var uploadTask = _firebaseStorage
                        .Child("images")
                        .Child(objectName)
                        .PutAsync(fileStream);

                    var downloadUrl = await uploadTask;
                    return downloadUrl;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi trong quá trình tải lên
                MessageBox.Show($"Đã xảy ra lỗi khi tải lên ảnh: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
