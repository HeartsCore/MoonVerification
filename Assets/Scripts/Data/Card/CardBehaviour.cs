using Core;
using UnityEngine;


public class CardBehaviour : MonoBehaviour
{

    private MeshRenderer faceImage;
    private Vector3 _origininalPosition;
    private Vector3 _origininalRotation;
    private bool _isFliped;
    private CardData _cardData;
    private bool isPressed = false;
    private float _cardDisplayTime;


    public static bool IsTweenRunning { get; private set; }
    
    
    private void OnEnable()
    {
        _isFliped = false;
    }

    private void Awake()
    {
        _cardData = Data.Instance.Card;
        _cardDisplayTime = _cardData.GetCardDisplayTime();
        faceImage = transform.GetChild(0).GetComponent<MeshRenderer>();

    }

}