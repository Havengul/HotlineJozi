using System.Runtime.InteropServices;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    private GameObject _player;

    private PlayerMovement _playerMovement;
    private Camera _camera;
    public bool CameraIsFollowingPlayer;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _camera = Camera.main;
        CameraIsFollowingPlayer = true;
        _playerMovement = _player.GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (CameraIsFollowingPlayer)
            CamFollowPlayer();
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CameraIsFollowingPlayer = false;
            _playerMovement.IsMoving = false;
        }
        else
        {
            CameraIsFollowingPlayer = true;
        }

        if (CameraIsFollowingPlayer)
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
        else
            LookAhead();
        
    }

    private void LookAhead()
    {

        var cameraPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        var direction = cameraPosition - transform.position / 2;
        if (cameraPosition.z >= -50)
            cameraPosition.z -= 10;
        if (PlayerIsVisible())
            transform.Translate(direction * Time.deltaTime);

    }

    private bool PlayerIsVisible()
    {
        return Mathf.Abs(transform.position.x - _player.transform.position.x) <= 7
               && Mathf.Abs(transform.position.y - _player.transform.position.y) <= 3;
    }
    
    public void CamFollowPlayer()
    {
        var newPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
        transform.position = newPosition;
    }

    public void SetFollowPlayer(bool set)
    {
        CameraIsFollowingPlayer = set;
    }
}