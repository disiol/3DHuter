using Photon.Pun;
using UnityEngine;

namespace Skripts
{
    public class PlayerManager : MonoBehaviour
    {
        private PhotonView _photonView;
        private void Start()
        {
            _photonView = GetComponent<PhotonView>();
            if(_photonView.IsMine)
                CreatePlayer();
        }

        private void CreatePlayer()
        {
            PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        }
    }
}
