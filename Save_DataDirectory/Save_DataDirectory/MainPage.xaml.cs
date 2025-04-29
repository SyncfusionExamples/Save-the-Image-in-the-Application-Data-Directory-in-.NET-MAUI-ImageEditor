using Syncfusion.Maui.ImageEditor;

namespace Save_DataDirectory;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private void OnImageSaving(object sender, ImageSavingEventArgs e)
    {
        e.Cancel = true;
        var stream = e.ImageStream;
        var dataDirectory = FileSystem.Current.AppDataDirectory; // Use the application's data directory
        var fileFullPath = Path.Combine(dataDirectory, "SavedImage.png");
        SaveStreamToFile(fileFullPath, stream);
    }
    public void SaveStreamToFile(string fileFullPath, Stream stream)
    {
        if (stream.Length == 0) return;

        // Create a FileStream object to write a stream to a file
        using (FileStream fileStream = File.Create(fileFullPath, (int)stream.Length))
        {
            // Fill the bytes[] array with the stream data
            byte[] bytesInStream = new byte[stream.Length];
            stream.Read(bytesInStream, 0, bytesInStream.Length);

            // Use FileStream object to write to the specified file
            fileStream.Write(bytesInStream, 0, bytesInStream.Length);
        }
    }
}