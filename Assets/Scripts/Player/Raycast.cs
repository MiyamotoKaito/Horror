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
    void Start()
    {

    }
    void Update()
    {
        Ray ray = povCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {

        }
            
    }

    private void GameOver()
    {
        
    }
}