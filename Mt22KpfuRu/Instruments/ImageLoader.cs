namespace Mt22KpfuRu.Instruments
{
    public class ImageLoader
    {
        public async Task<string?> Load(IWebHostEnvironment environment, string path, IFormFile file)
        {
            string fileName = file.FileName;
            if (!fileName.EndsWith(".png") && !fileName.EndsWith(".jpg") && !fileName.EndsWith(".jpeg") && !fileName.EndsWith(".jfif"))
            {
                return string.Empty;
            }
            Guid guidForName = new Guid();
            string extension = Path.GetExtension(fileName);
            string completePath = $"{environment.WebRootPath}{path}{guidForName}{extension}";
            while (File.Exists(completePath))
            {
                guidForName = new Guid();
                completePath = $"{environment.WebRootPath}{path}{guidForName}{extension}";
            }
            try
            {
                using (FileStream imageCreateStream = new FileStream(completePath, FileMode.Create))
                {
                    await file.CopyToAsync(imageCreateStream);
                }
            }
            catch
            {
                return null;
            }
            return $"{guidForName}{extension}";

            //"***.jpg" - Создано успешно
            //"" - файл не является картинкой
            //null - Ошибка записи
        }
    }
}
