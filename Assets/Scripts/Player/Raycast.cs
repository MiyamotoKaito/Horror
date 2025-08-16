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
            GetKey itemInfo = hit.collider.GetComponent<GetKey>();
            if (itemInfo != null && itemInfo.KeyType != null)
            {
                keyInfo.SetActive(true);
                keyNameText.text = itemInfo.KeyType.keyName;
                keyExplanationText.text = itemInfo.KeyType.explanation;
            }
            else if (hit.collider.CompareTag("GameOver"))
            {

            }
        }
    }
}