using FluentValidation;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.ValidationRules
{
    public class MovieValidation:AbstractValidator<Movie>
    {
        private bool EmptyGenre(IEnumerable<int> selectedGenres)
        {
            return selectedGenres == null ? true : false;
        }
        private bool EmptyYear(int year)
        {
            return year == 0 ? true : false;
        }
        private bool EmptyLanguage(string language)
        {
            return language == null ? true : false;
        }
        public MovieValidation()
        {
            RuleFor(x => x.SelectedGenres).Must(x => !EmptyGenre(x)).WithMessage("Genre is required");

            RuleFor(x => x.Year).Must(x => !EmptyYear(x)).WithMessage("Year is required");

            RuleFor(x => x.iso_639_1).Must(x => !EmptyLanguage(x)).WithMessage("Language is required");


        }
    }
}
