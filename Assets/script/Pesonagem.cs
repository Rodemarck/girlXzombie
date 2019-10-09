using System;
using script.Project.Controller.estatisticas;
using UnityEngine;

namespace script{
    public class Pesonagem : Coisa
    {
        private CharacterController _controller;
        private Vector3 direcao;
        public bool pulando;
        private float mouseX;
        private float mouseY;
        void Start()
        {
            movimento = new Movimento();
            pulando = false;
            Debug.Log("ola :");
            _controller = GetComponent<CharacterController>();
            mouseX = 180;    
    
        }

        private void Update(){
            move();
            gira();
        }

        private void move()
        {

            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && !Input.GetButton("Jump"))
            {
                if (movimento.velocidade < movimento.velocidadeMax)
                    movimento.velocidade += movimento.aceleracao;
            }else
            {
                movimento.velocidade = movimento.velocidadeBase;
            }
            
            direcao = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            direcao *= base.movimento.velocidade;
            if (!pulando && Input.GetButton("Jump"))
            {
                direcao.y = movimento.pulo;
                pulando = true;
            }
            direcao.y -= Gravidade.gravidade * Time.deltaTime;

            Vector3 v = transform.eulerAngles;
            direcao = Quaternion.Euler(v.x,0,v.z) * direcao ;
            _controller.Move(direcao * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "chao")
                pulando = false;
        }

        private void gira()
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(0, mouseX, 0);
        }
    }
}