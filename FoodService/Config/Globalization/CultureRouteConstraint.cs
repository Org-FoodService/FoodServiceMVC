namespace FoodService.Config.Globalization
{
    public class CultureRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey("culture"))
                return false;

            string culture = values["culture"]?.ToString();
            return IsCultureSupported(culture);
        }

        private bool IsCultureSupported(string culture)
        {
            // Adicione aqui a lógica para verificar se o idioma é suportado em sua aplicação
            // Por exemplo, verifique se ele está na lista de idiomas suportados
            return culture switch
            {
                "en" => true,
                "pt-BR" => true,
                // Adicione mais idiomas conforme necessário
                _ => false,
            };
        }
    }

}
