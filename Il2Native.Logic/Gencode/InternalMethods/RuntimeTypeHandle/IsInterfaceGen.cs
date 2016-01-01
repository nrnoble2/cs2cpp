﻿namespace Il2Native.Logic.Gencode.InternalMethods.RuntimeTypeHandler
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using PEAssemblyReader;

    public static class IsInterfaceGen
    {
        public static readonly string Name = "Boolean System.RuntimeTypeHandle.IsInterface(System.RuntimeType)";

        public static IEnumerable<Tuple<string, Func<IMethod, IMethod>>> Generate(ICodeWriter codeWriter)
        {
            var ilCodeBuilder = new IlCodeBuilder();
            ilCodeBuilder.LoadArgument(0);
            ilCodeBuilder.LoadField(OpCodeExtensions.GetFieldByName(codeWriter.System.System_RuntimeType, RuntimeTypeInfoGen.TypeAttributesField, codeWriter));
            ilCodeBuilder.LoadConstant((int)TypeAttributes.Interface);
            ilCodeBuilder.Duplicate();
            ilCodeBuilder.Add(Code.And);
            var jump = ilCodeBuilder.Branch(Code.Beq, Code.Beq_S);
            ilCodeBuilder.LoadConstant(0);
            ilCodeBuilder.Add(Code.Ret);
            ilCodeBuilder.Add(jump);
            ilCodeBuilder.LoadConstant(1);
            ilCodeBuilder.Add(Code.Ret);

            ilCodeBuilder.Parameters.Add(codeWriter.System.System_RuntimeType.ToParameter("type"));

            yield return ilCodeBuilder.Register(Name, codeWriter);
        }
    }
}