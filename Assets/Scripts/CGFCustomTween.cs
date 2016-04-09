///
/// INFORMACION
/// 
/// Proyecto: Chloroplast Games Framework
/// Juego: Chloroplast Games Framework
/// Fecha: <07/03/2016>
/// Autor: Chloroplast Games
/// Pagina web: http://www.chloroplastgames.com
/// Programadores: Adan Baro, David Cuenca
/// Descripción: Contiene todos los metodos de Tween personalizados (Vector2, Vector3, Vector4, Color, float, int).
/// 

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Assets.CGF.Systems.Tweens
{
    /// <summary>
    /// Estructura "Easing" que contiene un nombre y una curva de animación.
    /// </summary>
    [System.Serializable]
    public class Easing
    {
        public string easingName;
        public AnimationCurve easingCurve;
    }


    public class CGFCustomTween : MonoBehaviour
    {
        /// <summary>
        /// Lista de Estructuras (Curva - Nombre) que el usuario crea según sus necesidades.
        /// </summary>

        public List<Easing> easingList;

        /// <summary>
        /// Métodos de Tween según el tipo de dato que se necesite. 
        /// La estructura de los métodos es:
        /// Valor a devolver.
        /// Step: float para analizar la curva basado en la relación Tiempo - Duración.
        /// Increment: float que varia según el valor de la curva en el Step seleccionado.
        /// Ecuación que devuelve un valor distinto segun el incremento y los valores de inicio - final.
        /// </summary>
        static public Vector3 CustomTweenVector3(float time, float duration, Vector3 iniVector, Vector3 finVector, AnimationCurve curve)
        {
            Vector3 returnVector;
            float step = time / duration;
            float increment = curve.Evaluate(step);
            returnVector = new Vector3(iniVector.x + ((increment*(finVector.x - iniVector.x))/1),
                iniVector.y + ((increment*(finVector.y - iniVector.y))/1),
                iniVector.z + ((increment*(finVector.z - iniVector.z))/1));
            return returnVector;
        }

        static public Vector2 CustomTweenVector2(float time, float duration, Vector2 iniVector, Vector2 finVector, AnimationCurve curve)
        {
            Vector2 returnVector;
            float step = time / duration;
            float increment = curve.Evaluate(step);
            returnVector = new Vector2(iniVector.x + ((increment*(finVector.x - iniVector.x))/1),
                iniVector.y + ((increment*(finVector.y - iniVector.y))/1));
            return returnVector;
        }

        static public Vector4 CustomTweenVector4(float time, float duration, Vector4 iniVector, Vector4 finVector, AnimationCurve curve)
        {
            Vector4 returnVector;
            float step = time / duration;
            float increment = curve.Evaluate(step);
            returnVector = new Vector4(iniVector.x + ((increment*(finVector.x - iniVector.x))/1),
                iniVector.y + ((increment*(finVector.y - iniVector.y))/1),
                iniVector.z + ((increment*(finVector.z - iniVector.z))/1),
                iniVector.w + ((increment*(finVector.w - iniVector.w))/1));
            return returnVector;
        }

        static public Color CustomTweenColor(float time, float duration, Color iniColor, Color finColor, AnimationCurve curve)
        {
            Color returnColor;
            float step = time / duration;
            float increment = curve.Evaluate(step);
            returnColor = new Color(iniColor.r + ((increment*(finColor.r - iniColor.r))/1),
                iniColor.g + ((increment*(finColor.g - iniColor.g))/1),
                iniColor.b + ((increment*(finColor.b - iniColor.b))/1),
                iniColor.a + ((increment*(finColor.a - iniColor.a))/1));
            return returnColor;
        }

        static public float CustomTweenFloat(float time, float duration, float iniFloat, float finFloat, AnimationCurve curve)
        {
            float returnFloat;
            float step = time / duration;
            float increment = curve.Evaluate(step);
            returnFloat = (iniFloat + ((increment*(finFloat - iniFloat))/1));

            return returnFloat;
        }

        static public int CustomTweenInt(float time, float duration, int iniInt, int finInt, AnimationCurve curve)
        {
            int returnInt;
            float step = time / duration;
            float increment = curve.Evaluate(step);
            returnInt = Mathf.RoundToInt((iniInt + ((increment*(finInt - iniInt))/1)));

            return returnInt;
        }

        /// <summary>
        /// Método que selecciona la curva que queremos usar de la lista según su nombre.
        /// </summary>
        public AnimationCurve Curve(string Name)
        {
            AnimationCurve selectedCurve;
            for (int i = 0; i < easingList.Count; i++)
            {
                if (Name == easingList[i].easingName)
                {
                    selectedCurve = easingList[i].easingCurve;
                    return selectedCurve;
                }
            }
            return null;
        }
    }
}