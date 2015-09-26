using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTwo_20151.Models;
using AutoMapper;
using System.Data.Entity;
using Posts.ViewModels;

namespace TestTwo_20151.ViewModels
{
    public class RepoPicture : RepositoryBase
    {
        public IEnumerable<Picture> getAllPictures()
        {
            return dc.Pictures.AsEnumerable();
        }

        public Picture GetPicBYId(int? id)
        {
            var p = dc.Pictures.Find(id);

            return p == null ? null : p;
        }

        public Picture AddPicture(Picture p)
        {
            dc.Pictures.Add(p);
            dc.SaveChanges();
            return p;
        }

        public Picture addPicture(photoAdd newItem)
        {
            Picture picture = new Picture();

            byte[] logoBytes = new byte[newItem.PhotoUpload.ContentLength];
            newItem.PhotoUpload.InputStream.Read(logoBytes, 0, newItem.PhotoUpload.ContentLength);

            picture.Id = newItem.Id;
            picture.Name = newItem.Name;
            picture.Image = logoBytes;
            picture.ImageType = newItem.PhotoUpload.ContentType;


            dc.Pictures.Add(picture);
            dc.SaveChanges();

            return picture;

        }

        public void deletePicture(int? id)
        {
            dc.Pictures.Remove(dc.Pictures.Find(id));
            dc.SaveChanges();
        }
    }
}