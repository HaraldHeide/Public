/*

HELP_RemoteFileDownloader

The prefab "CanvasRemoteFileView"
should be placed as a World Canvas somewhere suitable in the Scene.

In the object beneath "ImageRemoteFileView" make sure that the 
"View ID" of the "Photon View" is unique in the scene.

Also provide the field "Input Url" in the "ImageDownloader" script
with a TextmeshPro InputField.
This will provide the url of the remote file that is to be downloaded.

Files from a public github directory seems to work fine. (JPG,PNG.etz.)

https://github.com/HaraldHeide/Public/raw/main/746775191764_ml.jpg

The public function OnButtonClickDownload() in the "ImageDownloader" script
should be called from a suitable UI Button or something. Needs only to be called from Observer view.


        //Example files:
        //https://github.com/HaraldHeide/Public/raw/main/746775191764_ml.jpg
        //https://github.com/HaraldHeide/Public/raw/main/FOLCertificate.pdf

*/