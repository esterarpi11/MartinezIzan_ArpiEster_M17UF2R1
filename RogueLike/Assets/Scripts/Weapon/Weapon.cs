using GameInputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public static Weapon Instance;
    public Arma arma;
    public float velocidadRotacionArma = 5f;
    SpriteRenderer spriteRenderer;

    // Variables para ajustar la posici�n relativa del arma
    public float offsetX = 1f;
    public float offsetY = 0f;

    // Nuevo campo para almacenar el transform del punto de inicio del disparo
    public Transform inicioDeDisparo;
    public Transform rotation; 
    public GameInput _inputs;

    private void Awake()
    {
        _inputs = new GameInput();
        _inputs.MainPlayer.Enable();
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = arma.icon; 
        _inputs.MainPlayer.Disparar.performed += DispararProyectil;

    }
    void Update()
    {
        // Obtener la posici�n del rat�n en el mundo
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calcular la direcci�n hacia el rat�n desde el punto de inicio del disparo
        Vector3 direccion = mousePos - inicioDeDisparo.position;

        // Calcular el �ngulo en radianes y convertirlo a grados
        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Rotar el arma hacia el rat�n
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), velocidadRotacionArma * Time.deltaTime);

        // Ajustar la posici�n del arma relativa al jugador
        transform.position = new Vector3(transform.parent.position.x + offsetX, transform.parent.position.y + offsetY, transform.position.z);

        if (rotation.rotation.z > 90 || rotation.rotation.z < -90) spriteRenderer.sprite = arma.iconReverse;
        else spriteRenderer.sprite = arma.icon;
    }

    void DispararProyectil(InputAction.CallbackContext obj)
    {
        Quaternion rotacionArma = transform.rotation;
        for (int i = 0; i < arma.numProyectiles; i++)
        {
            // Instancia el proyectil en el punto de inicio
            GameObject proyectil = Instantiate(arma.proyectil, inicioDeDisparo.position,rotacionArma);

            // Aplica fuerza al proyectil en la direcci�n calculada con dispersi�n
            Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();
            Vector3 direccion = Camera.main.ScreenToWorldPoint(Input.mousePosition) - inicioDeDisparo.position;

            if (arma.numProyectiles > 1)
            {
                // Calcula un �ngulo de dispersi�n aleatorio en el rango de 120 grados
                float dispersionAngle = Random.Range(-60f, 60f);

                // Rota la direcci�n original seg�n el �ngulo de dispersi�n
                Quaternion dispersionRotation = Quaternion.AngleAxis(dispersionAngle, Vector3.forward);
                Vector3 dispersedDirection = dispersionRotation * direccion.normalized;

                // Aplica fuerza al proyectil en la direcci�n dispersa
                rbProyectil.velocity = dispersedDirection * arma.velocidadProyectil;
            }
            else
            {
                // Si solo hay un proyectil, aplica la fuerza en la direcci�n original
                rbProyectil.velocity = direccion.normalized * arma.velocidadProyectil;
            }

            // Destruye el proyectil despu�s de un tiempo
            Destroy(proyectil, 2f);
        }
    }
}
