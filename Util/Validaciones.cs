using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Util
{
    public class Validaciones
    {
        public static bool esNuloOVacio(string campo)
        {
            if (String.IsNullOrEmpty(campo))
            {
                return true;
            }
            return false;
        }

        public static bool esEmailValido(string email)
        {
            if (!String.IsNullOrEmpty(email.Trim()))
            {
                for (int k = 0; k < email.Length; ++k)
                {
                    if (Convert.ToChar(email[k]) == 32)
                    {
                        return false;
                    }
                }

                if (Regex.IsMatch(email, "(@)(.+)$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            { 
                return false;
            } 
        }

        public static bool esClaveValida(string pass)
        {
            //- El campo Contraseña es requerido y debe contener al menos 6 caracteres
            if (!String.IsNullOrEmpty(pass.Trim()))
            {
                if (pass.Length == 0 || pass.Trim().Length < 6)
                    return false;

                else
                    return true;
            }
            else return false;
        }

        public static bool coincideClave(string pass, string repetirPass)
        {

            if (pass.Trim() != repetirPass.Trim())
                return false;
            else
                return true;
        }

        public static bool esApellidoValido(string ape)
        {
            if (!String.IsNullOrEmpty(ape.Trim()))
            {
                for (int k = 0; k < ape.Length; ++k)
                {
                    if (((Convert.ToChar(ape[k]) >= 65) && (Convert.ToChar(ape[k]) <= 90)) || ((Convert.ToChar(ape[k]) >= 97) && (Convert.ToChar(ape[k]) <= 122)) || (Convert.ToChar(ape[k]) == 32))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            } return false;
        }

        public static bool esLegajoValido(string leg)
        {
            //- El campo Legajo es requerido y debe contener sólo números
            if (!String.IsNullOrEmpty(leg.Trim()))
            {
                for (int k = 0; k < leg.Length; ++k)
                {
                    if (((Convert.ToChar(leg[k]) >= 48) && (Convert.ToChar(leg[k]) <= 57)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;

            }
            else return false;
        }

        public static bool esTelefonoValido(string tel)
        {
            if (!String.IsNullOrEmpty(tel.Trim()))
            {
                for (int k = 0; k < tel.Length; ++k)
                {
                    if (((Convert.ToChar(tel[k]) >= 48) && (Convert.ToChar(tel[k]) <= 57) || (Convert.ToChar(tel[k]) == 45)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esUsuarioValido(string usu)
        {
            if (!String.IsNullOrEmpty(usu.Trim()))
            {
                for (int k = 0; k < usu.Length; ++k)
                {
                    if (((Convert.ToChar(usu[k]) >= 65) && (Convert.ToChar(usu[k]) <= 90)) || ((Convert.ToChar(usu[k]) >= 96) && (Convert.ToChar(usu[k]) <= 122)))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else return false;
        }

        public static bool esDescripcionValida(string des)
        {
            if (!String.IsNullOrEmpty(des.Trim()))
            {
                for (int k = 0; k < des.Length; ++k)
                {
                    if (Convert.ToChar(des[k]) == 32 || ((Convert.ToChar(des[k]) >= 65) && (Convert.ToChar(des[k]) <= 90)) || ((Convert.ToChar(des[k]) >= 97) && (Convert.ToChar(des[k]) <= 122)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esDescripcionConNumerosValida(string des)
        {
            if (!String.IsNullOrEmpty(des.Trim()))
            {
                for (int k = 0; k < des.Length; ++k)
                {
                    if (Convert.ToChar(des[k]) == 32 || ((Convert.ToChar(des[k]) >= 48) && (Convert.ToChar(des[k]) <= 57)) || ((Convert.ToChar(des[k]) >= 65) && (Convert.ToChar(des[k]) <= 90)) || ((Convert.ToChar(des[k]) >= 97) && (Convert.ToChar(des[k]) <= 122)))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else return false;
        }

        public static bool esDescripcionComisionValida(string des)
        {
            //- El campo Descripción es requerido y no debe contener caracteres especiales
            if (!String.IsNullOrEmpty(des.Trim()))
            {
                bool band = true;
                for (int k = 0; k < des.Length; ++k)
                {
                    if (Convert.ToChar(des[k]) == 32 || ((Convert.ToChar(des[k]) >= 65) && (Convert.ToChar(des[k]) <= 90)) || ((Convert.ToChar(des[k]) >= 97) && (Convert.ToChar(des[k]) <= 122)))
                        continue;

                    else
                    {
                        band = false;
                        break;
                    }
                }
                if (band)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }

        }

        public static bool esCantidadHorasValidas(string hor)
        {
            if (!String.IsNullOrEmpty(hor.Trim()))
            {
                for (int k = 0; k < hor.Length; ++k)
                {
                    if ((Convert.ToChar(hor[k]) >= 48) && (Convert.ToChar(hor[k]) <= 57))
                    {
                        continue;
                    }

                    else return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool esAnioCursoValido(string anio)
        {
            //- El campo Año es requerido y debe contener un numero entre 1 y 6
            if (!String.IsNullOrEmpty(anio.Trim()))
            {
                for (int k = 1; k < 7; ++k)
                {
                    if (Convert.ToInt32(anio) == k)
                    {
                        return true;
                    }
                }

                return false;
            }
            else return false;
        }

        public static bool esAnioEspecialidadValido(string anio)
        {
            bool band = true;

            if (!String.IsNullOrEmpty(anio.Trim()))
            {
                for (int k = 0; k < anio.Length; ++k)
                {
                    if (Convert.ToChar(anio[k]) >= 48 && Convert.ToChar(anio[k]) <= 57)
                    {
                        continue;
                    }
                    else
                    {
                        band = false;
                        break;
                    }

                }

                if (band)
                {
                    int anioInt = Convert.ToInt32(anio);
                    if (anioInt >= 1 && anioInt <= 6)
                    {
                        return true;
                    }
                }
                else
                { return false; }
            }

            return false;
        }

        public static bool esAnioCalendarioValido(string anio)
        {
            bool band = true;

            if (!String.IsNullOrEmpty(anio.Trim()))
            {
                for (int k = 0; k < anio.Length; ++k)
                {
                    if (Convert.ToChar(anio[k]) >= 48 && Convert.ToChar(anio[k]) <= 57)
                    {
                        continue;
                    }
                    else
                    {
                        band = false;
                        break;
                    }

                }

                if (band)
                {
                    int anioInt = Convert.ToInt32(anio);
                    if (anioInt >= 1950 && anioInt <= DateTime.Today.Year)
                    {
                        return true;
                    }
                }
                else
                { return false; }
            }

            return false;
        }

        public static bool esCupoValido(string cupo)
        {

            //- El campo Cupo es requerido y debe ser como máximo de 100 personas
            if (!String.IsNullOrEmpty(cupo.Trim()))
            {
                int cupoInt = Convert.ToInt32(cupo);
                if (cupoInt >= 100 || cupoInt < 0)
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
