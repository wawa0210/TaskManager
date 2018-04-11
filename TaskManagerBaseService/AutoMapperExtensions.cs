using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace TaskManagerBaseService
{
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// obj to obj 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self)
        {
            if (self == null)
                throw new ArgumentNullException();

            return (TResult)Mapper.Map(self, self.GetType(), typeof(TResult));
        }
    }
}
