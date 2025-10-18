using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : GhostBehaviour
{
    private void OnDisable()
    {
        // do usuni�cia p�niej
        //Enable();
        // do w��czenia potem
        if (Ghost.Chase != null) Ghost.Chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // je�li aktywny (OnTriggerEnter mo�e aktywowa� si� nawet je�li zachowanie nie jest aktywne)
        // i je�li nie jest przestraszony oraz wszed� w kollider Node'a
        if (enabled && collision.TryGetComponent(out Node node))
        {
            // losujemy index kierunku z listy dostepnych w danym skrzy�owaniu/nodzie
            int index = Random.Range(0, node.availableDirections.Count);

            // zapobieganie zawracaniu - je�li wybrali�my kierunek wstecz/zmieniamy na kolejny
            // tylko je�li jest inna �cie�ka (w poziomie nie ma slepych uliczek, nie powinna taka sytuacja zaj��)
            if (node.availableDirections[index] == -Ghost.Movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            // ustalamy kierunek - nast�pny do obrania bo dopiero wchodzimy na w�ze�
            Ghost.Movement.SetDirection(node.availableDirections[index]);
        }
    }
}