using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Instagram.Data.Model.Post;

namespace Instagram.Business.Mappers
{
    public static class PostMapper
    {
        public static Post MapToDataModel(this Model.Post.Post businessModel, IMapper mapper)
        {
            return mapper.Map<Post>(businessModel);
        }

        public static List<Post> MapToDataModels(this List<Model.Post.Post> businessModel, IMapper mapper)
        {
            return businessModel.Select(p => p.MapToDataModel(mapper)).ToList();
        }

        public static Model.Post.Post MapToBusinessModel(this Post dataModel)
        {
            return new Model.Post.Post()
            {
                Description = dataModel.Description,
                DateCreated = dataModel.DateCreated,
                DateModified = dataModel.DateModified,
                Image = dataModel.Image,
                //Author = dataModel.Author.MapToBusinessModel()
            };
        } 

        public static List<Model.Post.Post> MapToBusinessModels(this List<Post> dataModel)
        {
            return dataModel.Select(p => p.MapToBusinessModel()).ToList();
        }
    }
}
