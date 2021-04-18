/*
 * 
 * 
 * Attach to an UI Image
 * Will display PNG, Jpg etz. Downloaded from web into Image 
 * NB Make sure View ID in PhotonVIew is identical in Observer view and 
 * 
 * 
 */ 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using Photon.Pun;
using TMPro;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(PhotonView))]
public class ImageDownloader : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Message;
    
    [SerializeField]
    private TMP_InputField InputUrl;


    Image _image => GetComponent<Image>();
    PhotonView  photonView => GetComponent<PhotonView>();
    void Start()
    {
        //Example files:
        //https://github.com/HaraldHeide/Public/raw/main/746775191764_ml.jpg
        //https://github.com/HaraldHeide/Public/raw/main/FOLCertificate.pdf
    }

    //Only called when in Observer view.
    //Make sure to provide a legal Url to fetch file from in the InputUrl field.
    public void OnButtonClickDownload()
    {
        _image.enabled = false;
        string url = InputUrl.text;
        this.photonView.RPC("Download", RpcTarget.AllBuffered, url);
    }

    #region PUN
    [PunRPC]
    private void Download(string url)
    {
        //Debug.Log("Download: " + url);
        StartCoroutine(LoadFromWeb(url));
    }

    IEnumerator LoadFromWeb(string url)
    {
        UnityWebRequest wr = new UnityWebRequest(url);
        DownloadHandlerTexture texDl = new DownloadHandlerTexture(true);
        wr.downloadHandler = texDl;
        yield return wr.SendWebRequest();
        if (wr.result == UnityWebRequest.Result.Success)
        {
            Texture2D t = texDl.texture;
            Sprite s = Sprite.Create(t, new Rect(0, 0, t.width, t.height), Vector2.zero, 1f);
            _image.sprite = s;
            _image.enabled = true;
        }
        else
        {
            if (Message != null)
                Message.text = "Error: " + wr.error;
            Debug.Log(wr.error);
        }
    }
    #endregion
}