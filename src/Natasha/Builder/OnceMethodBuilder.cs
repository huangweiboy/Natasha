﻿using Natasha.Complier;
using System;

namespace Natasha.Builder
{
    /// <summary>
    /// 一次性方法构建器
    /// </summary>
    /// <typeparam name="TBuilder"></typeparam>
    public class OnceMethodBuilder<TBuilder> : OnceMethodTemplate<TBuilder>
    {


        //使用默认编译器
        public MethodComplier ComplierOption;
        public OnceMethodBuilder() => ComplierOption = new MethodComplier();


        /// <summary>
        /// 编译返回委托
        /// </summary>
        /// <returns></returns>
        public Delegate Complie(object binder = null)
        {

            Builder();
            return ComplierOption.Complie(
                ClassNameScript,
                Script,
                MethodNameScript,
                DelegateType,
                binder);

        }




        /// <summary>
        /// 返回强类型委托
        /// </summary>
        /// <typeparam name="T">委托的强类型</typeparam>
        /// <returns></returns>
        public T Complie<T>(object binder=null) where T : Delegate
        {

            Builder();


            return (T)ComplierOption.Complie<T>(
                ClassNameScript,
                Script,
                MethodNameScript,
                binder);

        }

    }

}
