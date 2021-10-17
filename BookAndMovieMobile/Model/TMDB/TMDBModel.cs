using System;
using System.Collections.Generic;
using System.Text;
using BookAndMovieMobile.Model.Movie;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.ComponentModel;
using System.Linq;

using System.Threading.Tasks;
using BookAndMovieMobile.Model.TV;
using BookAndMovieMobile.Model.RestApi;
using BookAndMovieMobile.Model.Json;

namespace BookAndMovieMobile.Model.TMDB
{
    public class TMDBModel
    {
        public MovieJsonModel MovieJsonModel { get; set; }
        public MovieModel MovieModel { get; set; }
        public TVShowModel TVShowModel { get; set; }
        public TVShowJsonModel TVShowJsonModel { get; set; }
        public List<TVShowModel> GetTVShowsFromTMDB(string url)
        {
            GetContentFromTMDB(url: url, modelNo: 1);
            return TVShowJsonModel.Results;
        }

        public List<MovieModel> GetMoviesFromTMDB(string url)
        {
            GetContentFromTMDB(url: url, modelNo: 2);
            return MovieJsonModel.Results;
        }

        public MovieModel GetMovieFromTMDB(string url)
        {
            GetContentFromTMDB(url: url, modelNo: 3);
            return MovieModel;
        }

        public TVShowModel GetTVShowFromTMDB(string url)
        {
            GetContentFromTMDB(url: url, modelNo: 4);
            return TVShowModel;
        }

        private void GetContentFromTMDB(string url, int modelNo)
        {
            string clientUrl = url;
            var restApiModel = new RestApiModel(url: clientUrl, method: Method.GET);
            IRestResponse response = restApiModel.GetRestResponse();
            var jsonConvertModel = new JsonConvertModel(new SnakeCaseNamingStrategy());
            if (modelNo == 1)
                TVShowJsonModel = jsonConvertModel.GetContent<TVShowJsonModel>(response.Content);
            else if (modelNo == 2)
            {
                MovieJsonModel = jsonConvertModel.GetContent<MovieJsonModel>(response.Content);
            }
            else if (modelNo == 3)
            {
                MovieModel = jsonConvertModel.GetContent<MovieModel>(response.Content);

            }
            else
            {
                TVShowModel = jsonConvertModel.GetContent<TVShowModel>(response.Content);
            }

        }
    }
}
