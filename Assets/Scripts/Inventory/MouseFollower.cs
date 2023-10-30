using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class MouseFollower : MonoBehaviour
{
    [SerializeField] public Image FollowImage;
    [SerializeField] public Canvas canvas;

    private void Start() {
        SetAlpha(FollowImage,0f);
        this.gameObject.SetActive(false);
    }
    private void Update() {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,Input.mousePosition,canvas.worldCamera,out localPoint);
        transform.position = canvas.transform.TransformPoint(localPoint);
    }
    public void SetFollow(InventoryItemUI item) {
        SetAlpha(FollowImage,0.5f);
        this.transform.position = item.transform.position;
        gameObject.SetActive(true);
        FollowImage.sprite = item.itemImage.sprite;
    }

    public void SetAlpha(Image image ,float val) {
        Color tempcolor = image.color;
        tempcolor.a = val;
        image.color = tempcolor;
    }

    public void EndFollow() {
        SetAlpha(FollowImage,0f);
        this.gameObject.SetActive(false);
    }
}
