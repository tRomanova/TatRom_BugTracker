﻿using TatRom_BugTracker.Services.Interfaces;

namespace TatRom_BugTracker.Services
{
    public class BTFileService : IBTFileService
    {
        #region Globals
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
		//private readonly string _defaultBTUserImageSrc = "/img/DefaultUserImage.png";
		//private readonly string _defaultCompanyImageSrc = "/img/DefaultCompanyImage.png";
		//private readonly string _defaultProjectImageSrc = "/img/DefaultProjectImage.png";

		private readonly string _defaultBTUserImageSrc = "/img/BTUserImage.jpg";
		private readonly string _defaultCompanyImageSrc = "/img/CompanyImage.jpg";
		private readonly string _defaultProjectImageSrc = "/img/ProjectImage.jpg";
		#endregion
		#region Convert Byte Array to File
		public string ConvertByteArrayToFile(byte[] fileData, string extension, int imageType)
        {
            if ((fileData == null || fileData.Length == 0))
            {
                switch (imageType)
                {
                    // BTUser Image based on the 'DefaultImage' Enum
                    case 1: return _defaultBTUserImageSrc;
                    // Company Image based on the 'DefaultImage' Enum
                    case 2: return _defaultCompanyImageSrc;
                    // Project Image based on the 'DefaultImage' Enum
                    case 3: return _defaultProjectImageSrc;
                }
            }
            try
            {
                string imageBase64Data = Convert.ToBase64String(fileData!);
                return string.Format($"data:{extension};base64,{imageBase64Data}");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Convert File to Byte Array
        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            try
            {
                using MemoryStream memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                byte[] byteFile = memoryStream.ToArray();
                memoryStream.Close();

                return byteFile;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Format File Size
        public string FormatFileSize(long bytes)
        {
            int counter = 0;
            decimal fileSize = bytes;
            while (Math.Round(fileSize / 1024) >= 1)
            {
                fileSize /= bytes;
                counter++;
            }
            return string.Format("{0:n1}{1}", fileSize, suffixes[counter]);
        }
        #endregion
        #region Get File Icon
        public string GetFileIcon(string file)
        {
            string fileImage = "default";
            if (!string.IsNullOrWhiteSpace(file))
            {
                fileImage = Path.GetExtension(file).Replace(".", "");
                return $"/img/contenttype/{fileImage}.png";
            }
            return fileImage;
        }
        #endregion    
    }
}

