using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private Image barImage;

    public void UpdateHealthBar(float maxHealth,float Health)
    {
        barImage.fillAmount = Health / maxHealth;
    }
}
