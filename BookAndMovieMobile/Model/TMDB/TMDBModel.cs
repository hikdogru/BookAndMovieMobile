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
            return TVShowJsonModel.Results ?? TVShowJsonModel.Items;
        }

        public List<MovieModel> GetMoviesFromTMDB(string url)
        {
            GetContentFromTMDB(url: url, modelNo: 2);
            return MovieJsonModel.Results ?? MovieJsonModel.Items;
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

        public void PostContentToTMDB(string url, byte[] data)
        {
            var json = Encoding.UTF8.GetString(data);
            var client = new RestApiModel(url: url, method: Method.POST);
            var request = client.Request;
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.GetRestResponse(request);

        }

        public void DeleteContentFromTMDB(string url)
        {
            var client = new RestApiModel(url: url, Method.DELETE);
            var request = client.Request;
            var response = client.GetRestResponse(request);
        }

        public void RemoveContentFromTMDB(int medialistId, int mediaId)
        {
            string clientUrl = $"https://api.themoviedb.org/3/list/{medialistId}/remove_item?api_key=ebd943da4f3d062ae4451758267b1ca9";
            var request = new RestRequest(Method.POST);
            string jsonContent = "{\"items\":[{\"media_id\":" + mediaId + "}]}";
            request.AddHeader("content-type", "application/json;charset=utf-8");
            var client = new RestApiModel(url: clientUrl, request: request);
            IRestResponse response = client.GetRestResponse(request: client.Request);
        }

        public void PostContentToTMDB(int medialistId, int mediaId, string mediaType, Method method)
        {
            string clientUrl = $"https://api.themoviedb.org/4/list/{medialistId}/items?api_key=ebd943da4f3d062ae4451758267b1ca9";
            var request = new RestRequest(method);
            string jsonContent = "{\"items\":[{\"media_type\":\"" + mediaType + "\",\"media_id\":" + mediaId + "}]}";
            request.AddHeader("content-type", "application/json;charset=utf-8");
            request.AddHeader("authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYmYiOjE2MzUyNTI0MzEsImF1ZCI6ImViZDk0M2RhNGYzZDA2MmFlNDQ1MTc1ODI2N2IxY2E5IiwianRpIjoiMzY1NzY0OSIsInNjb3BlcyI6WyJhcGlfcmVhZCIsImFwaV93cml0ZSJdLCJ2ZXJzaW9uIjoxLCJzdWIiOiI2MTQ1ZDA5MjA0ODYzODAwMmNlNTUzZDcifQ.XLKFsZFe3sqtrqQWU3tbZQgHWbZniBRT2vLq2A__XVM");
            request.AddParameter("application/json;charset=utf-8", jsonContent, ParameterType.RequestBody);
            var client = new RestApiModel(url: clientUrl, request: request);
            IRestResponse response = client.GetRestResponse(request: client.Request);
        }
    }
}
