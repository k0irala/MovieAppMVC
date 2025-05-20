using System.Diagnostics;
using System.Security.AccessControl;
using FIrst_App.Data;
using FIrst_App.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FIrst_App.Services
{
    public class DatabaseOperations(MovieContext dbContext)
    {
        public async Task<Boolean> AddMovie(MovieViewModel movieViewModel, int id)
        {
            if (id == 0)
            {
                var movieData = new MovieViewModel()
                {
                    Title = movieViewModel.Title,
                    GenreId = movieViewModel.GenreId,
                    Rating = movieViewModel.Rating,
                    ReleaseDate = movieViewModel.ReleaseDate,
                };
                await dbContext.movie.AddAsync(movieData);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                var movieData = new MovieViewModel()
                {
                    Id = movieViewModel.Id,
                    Title = movieViewModel.Title,
                    GenreId = movieViewModel.GenreId,
                    Rating = movieViewModel.Rating,
                    ReleaseDate = movieViewModel.ReleaseDate,
                };
                dbContext.movie.Update(movieData);
                await dbContext.SaveChangesAsync();
                return true;
            }


        }
        public List<MovieViewModel> getAllMovie()
        {
            //var movies = dbContext.movie
            //    .Include(i => i.genre)
            //    .ToList();

            //var allMovies = movies.Select(x => new MovieViewModel
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    ReleaseDate = x.ReleaseDate,
            //    Rating = x.Rating,
            //    GenreId = x.genre != null ? x.genre.Id : 0,
            //    genre = x.genre
            //}).ToList();
            var allMovies = dbContext.MovieWithGenre.FromSqlRaw("GetAllMovies").ToList();
            var movies = allMovies.Select(s => new MovieViewModel
            {
                Id = s.Id,
                Title = s.Title,
                ReleaseDate = s.ReleaseDate,
                Rating = s.Rating,
                GenreId = s.GenreId,
                genre = new GenreViewModel
                {
                    Id = s.GenreId,
                    GenreName = s.GenreName

                }
            }).ToList();

            return movies;
        }

        public async Task<MovieViewModel> getMovieById(int id)
        {
            var movie = await dbContext.movie.SingleOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return new MovieViewModel();
            }
            return movie;
        }
        public async Task<Boolean> deleteMovie(int id)
        {
            var getMovie = await dbContext.movie.SingleOrDefaultAsync(x => x.Id == id);
            if (getMovie == null)
            {
                return false;
            }
            dbContext.movie.Remove(getMovie);
            var rowsAffected = await dbContext.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<Boolean> addGenre(GenreViewModel genreViewModel, int id, string GenreName)
        {
            if (id == 0)
            {
                //check existing genres
                var existingGenre = dbContext.genre.SingleOrDefault(x => x.GenreName == GenreName);
                if (existingGenre == null)
                {
                    var addGenres = new GenreViewModel()
                    {
                        GenreName = genreViewModel.GenreName,
                    };
                    dbContext.genre.Add(addGenres);
                    var rowsAffected = await dbContext.SaveChangesAsync();
                    return rowsAffected > 0;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                //check existing genres
                var existingGenre = dbContext.genre.SingleOrDefault(x => x.GenreName == GenreName && x.Id != id);
                if (existingGenre == null)
                {
                    var addGenres = new GenreViewModel()
                    {
                        Id = genreViewModel.Id,
                        GenreName = genreViewModel.GenreName,
                    };
                    dbContext.genre.Update(addGenres);
                    var rowsAffected = await dbContext.SaveChangesAsync();
                    return rowsAffected > 0;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<GenreViewModel> getAllGenres()
        {
            var allGenres = dbContext.genre.FromSqlRaw("GetAllGenres").ToList();
            return allGenres;
        }

        public List<SelectListItem> GetGenreSelectList()
        {
            return dbContext.genre
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.GenreName
                }).ToList();
        }
        public async Task<GenreViewModel> getGenreById(int id)
        {
            var genres = await dbContext.genre.SingleOrDefaultAsync(x => x.Id == id);
            if (genres == null)
            {
                return new GenreViewModel();
            }
            return genres;
        }

        public async Task<Boolean> deleteGenres(int id)
        {
            var genreExists = await dbContext.genre.FirstOrDefaultAsync(x => x.Id == id);
            if (genreExists != null)
            {
                dbContext.Remove(genreExists);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
