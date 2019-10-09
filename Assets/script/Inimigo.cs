using System;
using script.Project.Controller.estatisticas;
using UnityEngine;

namespace script
{
    public class Inimigo:Coisa
    {
        public GameObject alvo;
        private CharacterController _controller;
        private Transform _transform;
        private Transform _transformAlvo;
        private Vector3 direcao;
        private void Start()
        {
            movimento = new Movimento();
            movimento.velocidade = movimento.velocidadeBase/5;
            Debug.Log(movimento.velocidade);
            //    alvo = GameObject.Find("mono");
            _controller = GetComponent<CharacterController>();
            
        }

        private void Update()
        {
            _transformAlvo = alvo.GetComponent<Transform>();
            _transform = GetComponent<Transform>();

            direcao = new Vector3();
            direcao.x = (_transform.position.x < _transformAlvo.position.x) ? movimento.velocidade : -movimento.velocidade;
            direcao.z = (_transform.position.z < _transformAlvo.position.z) ? movimento.velocidade : -movimento.velocidade;
            _controller.Move(direcao * Time.deltaTime);
        }
    }
}