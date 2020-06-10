﻿using MarketoApiLibrary.Asset.Folders.Response;

namespace MarketoApiLibrary.Asset.Folders
{
    public interface IFolderController
    {
        FoldersResponse GetFolders(int rootFolderId, string rootFolderType = "Folder");
        FoldersResponse GetFolderByName(string folderName);
        FoldersResponse GetFolderById(int folderId, string folderType);
        FolderContentsResponse GetFolderContents(int folderId, int maxReturn = 20, int offset = 20, string folderType = "Folder");
    }
}
