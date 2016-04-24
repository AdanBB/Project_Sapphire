/// INFORMACION
/// 
/// Proyecto: Chloroplast Games Framework
/// Juego: Chloroplast Games Framework
/// Fecha: <23/03/2016>
/// Autor: Chloroplast Games
/// Pagina web: http://www.chloroplastgames.com
/// Programadores: Adán Baró.
/// Descripción: Rota un objeto según los parametros.
///

using System.Collections;
using UnityEngine;
using Assets.CGF.Systems.Tweens;

// Local Namespace
namespace Assets.CGF.Systems.Transform   {

    /// <summary>
    /// Rota un objeto según los parametros.
    /// </summary>
    public class CGFRotatoryObjectBehavior : MonoBehaviour {
    
    #region Public Variables

    /// <summary>    
    /// Activa o desactiva el inicio automatico de la rotación.
    /// </summary>
    public bool automatic;

    /// <summary>    
    /// Enumera los modos de rotación.
    /// </summary>
    public enum PeriodType { Loop, Cycle}

    /// <summary>    
    /// Enumeración de tipos de periodos.
    /// </summary>
    public PeriodType periodType;

    /// <summary>    
    /// Activa o desactiva el efecto de Ping Pong.
    /// </summary>
    public bool pingPong;

    /// <summary>    
    /// Numero de ciclos a realizar.
    /// </summary>
    public float cycles;

    /// <summary>    
    /// Angulo inicial.
    /// </summary>
    public Vector3 initialAngle;

    /// <summary>    
    /// Angulo final.
    /// </summary>
    public Vector3 finalAngle;

    /// <summary>    
    /// Duración de la rotación.
    /// </summary>
    public float duration;

    #endregion
 
    #region Private Variables

    /// <summary>    
    /// Rotación actual.
    /// </summary>
    private Vector3 _actualRotation;

    /// <summary>    
    /// Contador de tiempo local.
    /// </summary>
    private float _localtime;

    /// <summary>    
    /// Curva de animación.
    /// </summary>
    private AnimationCurve _curve;

    /// <summary>    
    /// Activa o desactiva la animación de vuelta.
    /// </summary>
    private bool _comeBack;

    /// <summary>    
    /// Numero de ciclos realizados.
    /// </summary>
    private float _cycleCount;

    #endregion
 
    #region Main Methods

    void Start () {

        _cycleCount = 0;

        _comeBack = false;

        _curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        transform.Rotate(initialAngle);
    }

    void FixedUpdate () {

        _actualRotation = transform.eulerAngles;

        if (automatic)
        {
            RotatoryObjectBehavior();
        }
    }
    #endregion

    #region Utility Methods

    /// <summary>    
    /// Rotación segun el tipo seleccionado.
    /// </summary>
    public void RotatoryObjectBehavior()
    {
        if (periodType == PeriodType.Loop)
        {             
            if (pingPong)
            {
                if (_comeBack == false)
                {
                    _localtime += Time.deltaTime;
                    transform.rotation = Quaternion.Euler(CGFCustomTween.CustomTweenVector3(_localtime, duration, initialAngle, finalAngle, _curve));

                    if (_localtime >= duration)
                    {
                        _localtime = 0;
                        _comeBack = true;
                    }
                }
                if (_comeBack)
                {
                    _localtime += Time.deltaTime;
                    transform.rotation = Quaternion.Euler(CGFCustomTween.CustomTweenVector3(_localtime, duration, finalAngle, initialAngle, _curve));

                    if (_localtime >= duration)
                    {
                        _localtime = 0;
                        _comeBack = false;
                    }
                }
 
            }
            else
            {
                _localtime += Time.deltaTime;
                transform.rotation = Quaternion.Euler(CGFCustomTween.CustomTweenVector3(_localtime, duration, initialAngle, finalAngle, _curve));

                if (_localtime >= duration)
                {
                    ResetAngle();
                    _localtime = 0;
                }
            }
        }
        if (periodType == PeriodType.Cycle )
        {
            if (pingPong && _cycleCount < cycles)
            {
                if (_comeBack == false)
                {
                    _localtime += Time.deltaTime;
                    transform.rotation = Quaternion.Euler(CGFCustomTween.CustomTweenVector3(_localtime, duration, initialAngle, finalAngle, _curve));

                    if (_localtime >= duration)
                    {
                        _cycleCount = _cycleCount + 1;
                        _localtime = 0;
                        _comeBack = true;
                    }
                }
                if (_comeBack)
                {
                    _localtime += Time.deltaTime;
                    transform.rotation = Quaternion.Euler(CGFCustomTween.CustomTweenVector3(_localtime, duration, finalAngle, initialAngle, _curve));

                    if (_localtime >= duration)
                    {
                        _cycleCount = _cycleCount + 1;
                        _localtime = 0;
                        _comeBack = false;
                    }
                }
            }
            else
            {
                if (_cycleCount < cycles)
                {
                    _localtime += Time.deltaTime;
                    transform.rotation = Quaternion.Euler(CGFCustomTween.CustomTweenVector3(_localtime, duration, initialAngle, finalAngle, _curve));

                    if (_localtime >= duration)
                    {
                        _cycleCount = _cycleCount + 1;
                        _localtime = 0;
                    }
                }
            }
        }  
    }

    /// <summary>    
    /// Reinicia la rotacion al angulo inicial.
    /// </summary>
    public void ResetAngle()
    {
        if ((_actualRotation.x == finalAngle.x) || (_actualRotation.y == finalAngle.y) || (_actualRotation.z == finalAngle.z))
        {
            transform.rotation = Quaternion.Euler(initialAngle);
        }
    }
    #endregion

    #region Utility Events
    #endregion
    }
}