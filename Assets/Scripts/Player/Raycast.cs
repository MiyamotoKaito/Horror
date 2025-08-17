using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("レイキャスト設定")]
    [SerializeField] private Camera povCamera;
    [SerializeField] private float raycastDistance;

    [Header("UI設定")]
    [SerializeField] private GameObject keyInfo;
    [SerializeField] private Text keyNameText;
    [SerializeField] private Text keyExplanationText;
    [SerializeField] private RawImage KeyDisplay;

    private GameObject currentKeyObject;
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
                }

                //鍵の情報をUI上に表示
                keyNameText.text = itemInfo.KeyType.keyName;
                keyExplanationText.text = itemInfo.KeyType.explanation;
                KeyDisplay.texture = itemInfo.KeyType.KeyObject;

                //鍵の取得と同時にUIを非表示にする
                if (Input.GetKeyDown(KeyCode.F))
                {
                    keyInfo.SetActive(false);

                    if (currentKeyObject != null)
                    {
                        DestroyImmediate(currentKeyObject);
                        currentKeyObject = null;
                    }
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
            }
        }
    }
}