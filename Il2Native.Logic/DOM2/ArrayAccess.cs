﻿namespace Il2Native.Logic.DOM2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.CodeAnalysis.CSharp;

    public class ArrayAccess : Expression
    {
        private readonly IList<Expression> _indices = new List<Expression>();

        public override Kinds Kind
        {
            get { return Kinds.ArrayAccess; }
        }

        public Expression Expression { get; set; }

        public IList<Expression> Indices
        {
            get { return this._indices; }
        }

        internal void Parse(BoundArrayAccess boundArrayAccess)
        {
            base.Parse(boundArrayAccess);
            this.Expression = Deserialize(boundArrayAccess.Expression) as Expression;
            foreach (var boundExpression in boundArrayAccess.Indices)
            {
                var item = Deserialize(boundExpression) as Expression;
                Debug.Assert(item != null);
                this._indices.Add(item);
            }
        }

        internal override void WriteTo(CCodeWriterBase c)
        {
            this.Expression.WriteTo(c);
            c.TextSpan("->operator[](");

            if (this._indices.Count > 1)
            {
                c.TextSpan("{");
            }

            var any = false;
            foreach (var index in this._indices)
            {
                if (any)
                {
                    c.TextSpan(",");
                    c.WhiteSpace();
                }

                index.WriteTo(c);

                any = true;
            }

            if (this._indices.Count > 1)
            {
                c.TextSpan("}");
            }

            c.TextSpan(")");
        }
    }
}
