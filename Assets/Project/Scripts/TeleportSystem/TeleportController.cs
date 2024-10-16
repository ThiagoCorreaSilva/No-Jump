using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private Transform teleport_1, teleport_2;
    [SerializeField] private float teleportCooldown;
    public TMP_Text popUp;
    public Transform player;
    public bool canTeleport;

    private void Start()
    {
        canTeleport = true;
        popUp.gameObject.SetActive(false);
    }

    public void TeleportPlayer(string _teleportName)
    {
        if (!canTeleport) return;

        canTeleport = false;

        switch (_teleportName)
        {
            case "1":
                player.position = new Vector2(teleport_2.position.x, teleport_2.position.y + 0.5f);
                break;

            case "2":
                player.position = new Vector2(teleport_1.position.x, teleport_1.position.y + 0.5f);
                break;
        }

        Invoke(nameof(ActiveTeleport), teleportCooldown);
    }

    private void ActiveTeleport()
    {
        canTeleport = true;
    }
}