using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private Transform teleport_1, teleport_2;
    public Transform player;
    private bool canTeleport;

    private void Start()
    {
        canTeleport = true;
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

        Invoke(nameof(ActiveTeleport), 0.5f);
    }

    private void ActiveTeleport()
    {
        canTeleport = true;
    }
}