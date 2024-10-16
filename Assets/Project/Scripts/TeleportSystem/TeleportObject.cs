using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    [SerializeField] private TeleportController tpController;
    private bool inside;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inside)
            tpController.TeleportPlayer(gameObject.name);

        if (!tpController.canTeleport) tpController.popUp.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            if (tpController.player == null) tpController.player = _other.gameObject.GetComponent<Transform>();

            tpController.popUp.gameObject.SetActive(true);
            inside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            tpController.popUp.gameObject.SetActive(false);
            inside = false;
        }
    }
}