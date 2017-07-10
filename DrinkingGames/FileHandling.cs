using System;
using System.Threading.Tasks;
using PCLStorage;

namespace DrinkingGames
{
    public class FileHandling
    {
       async public static Task<IFile> getFile(string Folder, string File, bool Append){
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync(Folder, CreationCollisionOption.OpenIfExists);
            IFile file;
            if (Append)
            {

                file = await folder.CreateFileAsync(File, CreationCollisionOption.OpenIfExists);
            }
            else{
                file = await folder.CreateFileAsync(File, CreationCollisionOption.ReplaceExisting);
            }
            return file;
        }
    }
}
