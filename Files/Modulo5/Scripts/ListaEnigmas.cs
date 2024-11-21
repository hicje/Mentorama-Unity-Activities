using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaEnigmas: MonoBehaviour
{
    [SerializeField] public List<Enigma> listaEnigmasEasy = new List<Enigma>();
    [SerializeField] public List<Enigma> listaEnigmasMedium = new List<Enigma>();
    [SerializeField] public List<Enigma> listaEnigmasHard = new List<Enigma>();
}