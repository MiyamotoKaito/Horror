using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("レイキャスト設定")]
    [SerializeField] private Camera povCamera;
    [SerializeField] private float raycastDistance;

    [Header("UI設定")]
    [SerializeField] private GameObject keyInfo;
    [SerializeField] private TextMeshProUGUI keyNameText;
    [SerializeField] private TextMeshProUGUI keyExplanationText;
    [SerializeField] private RawImage KeyDisplay;

    public UnityEvent _action;

    void Start()
    {
        keyInfo.SetActive(false);
    }
    void Update()
    {

        Ray ray = povCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            GetKey itemInfo = hit.collider.GetComponent<GetKey>();
            if (itemInfo != null && itemInfo.KeyType != null)
            {
                //UIが非アクティブの時だけに表示する
                if (!keyInfo.activeInHierarchy)
                {
                    keyInfo.SetActive(true);
                    _action.Invoke();
                    Debug.Log("UI表示されてるよ");
                }

                //鍵の情報をUI上に表示
                keyNameText.text = itemInfo.KeyType.keyName;
                keyExplanationText.text = itemInfo.KeyType.explanation;
                KeyDisplay.texture = itemInfo.KeyType.KeyTexture;

                //鍵の取得と同時にUIを非表示にする
                if (Input.GetKeyDown(KeyCode.F))
                {
                    keyInfo.SetActive(false);
                    Debug.Log("鍵げっちゅ");
                }
            }
            if (hit.collider.CompareTag("GameOver"))
            {
                EyeContact enemyFace = FindObjectOfType<EyeContact>();
                enemyFace.GameOver();
            }
        }
        else
        {
            if (keyInfo.activeInHierarchy)
            {
                keyInfo.SetActive(false);
                Debug.Log("鍵から離れた");
            }
        }
    }
}