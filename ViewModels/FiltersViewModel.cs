using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Filters;

namespace ViewModels
{
    public class FiltersViewModel
    {
        public static Dictionary<string, IFilteringStrategy> FilteringStrategies;
        public FilteringManager FilteringManager { get; set; }

        public FiltersViewModel(FilteringManager filteringManager)
        {
            FilteringManager = filteringManager;
            FilteringStrategies = new Dictionary<string, IFilteringStrategy>()
            {
                {"Negation", new NegationFilteringStrategy() },
                {"Contrast",new ContrastFilteringStrategy() },
                {"Brightness", new BrightnessFilteringStrategy() },
                {"Gamma",new GammaFilteringStrategy() },
                {"Custom",new CustomFunctionFilteringStrategy() },
                {"None", null }
            };
        }
    }
}
