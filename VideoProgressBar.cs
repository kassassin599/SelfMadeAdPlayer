using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgressBar : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    private Image progress;

    public GameObject skipButton;

    public VideoClip[] videoClips;

    int selectedVideo = 0;

    private void Awake()
    {
        progress = GetComponent<Image>();
    }

    private void Start()
    {
        InitializeVideoClip();
    }

    private void InitializeVideoClip()
    {
        if (videoClips.Length > 0)
        {
            selectedVideo = Random.Range(0, videoClips.Length - 1);
            print(selectedVideo);
        }
        videoPlayer.clip = videoClips[selectedVideo];

        StartCoroutine(ActivateSkipButton());
    }

    IEnumerator ActivateSkipButton()
    {
        skipButton.SetActive(false);
        yield return new WaitForSeconds(10);
        print("Waited for 10 seconds");
        skipButton.SetActive(true);
    }

    private void Update()
    {
        if (videoPlayer.frameCount>0)
        {
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
        if (progress.fillAmount >= 0.99)
        {
            GameManager.Instance.gameState = GameManager.GameState.Play;
            FuelManager.Instance.fuel = 100;
            InitializeVideoClip();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform, eventData.position, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        var frame = videoPlayer.frameCount * pct;
        videoPlayer.frame = (long)frame;
    }

    public void SkipVideoButton()
    {
        print("Skip Video");

        videoPlayer.frame = (long)videoPlayer.frameCount;
    }
}
