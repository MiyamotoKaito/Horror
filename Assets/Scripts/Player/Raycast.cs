using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("���C�L���X�g�ݒ�")]
    [SerializeField] private Camera povCamera;
    [SerializeField] private float raycastDistance;

    [Header("UI�ݒ�")]
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
                //UI����A�N�e�B�u�̎������ɕ\������
                if (!keyInfo.activeInHierarchy)
                {
                    keyInfo.SetActive(true);
                }

                //���̏���UI��ɕ\��
                keyNameText.text = itemInfo.KeyType.keyName;
                keyExplanationText.text = itemInfo.KeyType.explanation;
                KeyDisplay.texture = itemInfo.KeyType.KeyObject;

                //���̎擾�Ɠ�����UI���\���ɂ���
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