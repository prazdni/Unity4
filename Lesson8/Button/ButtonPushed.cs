using UnityEngine;


public class ButtonPushed : MonoBehaviour
{

    [SerializeField] private GameObject _connectedCube;

    private Color _defaultColor; 

    private void Start()
    {
        _defaultColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.Equals(_connectedCube))
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(_connectedCube))
        {
            GetComponent<MeshRenderer>().material.color = _defaultColor;
        }
    }
}
