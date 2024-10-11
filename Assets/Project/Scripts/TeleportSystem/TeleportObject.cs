using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    [SerializeField] private TeleportController tpController;

    private void OnTriggerEnter2D(Collider2D _other)
    {
        Debug.Log("Colisao");

        if (_other.gameObject.CompareTag("Player"))
        {
            if (tpController.player == null) tpController.player = _other.gameObject.GetComponent<Transform>();
            tpController.TeleportPlayer(gameObject.name);
        }
    }
}