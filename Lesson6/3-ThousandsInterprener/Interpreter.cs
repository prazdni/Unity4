using System;
using TMPro;
using UnityEngine;

namespace Lesson6.Interpreter
{
    public class Interpreter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private TMP_InputField _inputField;

        private void Start()
        {
            _inputField.onValueChanged.AddListener(Interpret);
        }

        private void Interpret(string value)
        {
            if (Double.TryParse(value, out var number))
            {
                _text.text = ToThousands(number);
            }
            else
            {
                _text.text = String.Empty;
            }
        }

        private string ToThousands(double number)
        {
            switch (CountThousands(ref number))
            {
                case 0:
                    return String.Format($"{number}");
                case 1:
                    return String.Concat(Convert.ToInt32(number).ToString(), "K");
                case 2:
                    return String.Concat(Convert.ToInt32(number).ToString(), "M");
                case 3:
                    return String.Concat(Convert.ToInt32(number).ToString(), "B");
                default:
                    throw new ArgumentOutOfRangeException(nameof(number));
            }
        }

        private int CountThousands(ref double number)
        {
            int countThousands = 0;

            while (Math.Abs(number) >= 1000)
            {
                countThousands++;
                number /= 1000;
            }

            return countThousands;
        }
    }
}