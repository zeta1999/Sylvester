﻿namespace Sylvester.tf

open System
open System.Collections.Generic;
open System.Runtime.CompilerServices

open TensorFlow

open Sylvester
open Sylvester.Arithmetic
open Sylvester.Arithmetic.N10
open Sylvester.Collections
open Sylvester.Graphs
open Sylvester.Tensors

[<AutoOpen>]
module Matrix =
    type Matrix<'dim0, 'dim1, 't when 'dim0 :> Number and 'dim1 :> Number and 't : struct and 't:> ValueType and 't: (new: unit -> 't) and 't :> IEquatable<'t> and 't :> IFormattable and 't :> IComparable>(graph:ITensorGraph, name:string, head:Node, output:int) =
        inherit Tensor<two, 't>(graph, name, head, output, [|number<'dim0>.Val; number<'dim1>.Val|])
        interface IMatrix
        member x.Dim0 = number<'dim0>
        member x.Dim1 = number<'dim1>

        new(name:string) = 
            let g = defaultGraph
            let shape = [|number<'dim0>.Val; number<'dim1>.Val|]
            new Matrix<'dim0, 'dim1, 't>(g, name, new Node(g, "Placeholder", tf(g).Placeholder(dataType<'t>, shape), []), 0)

        static member (+)(l:Matrix<'dim0, 'dim1, 't>, r:Matrix<'dim0, 'dim1, 't>) = 
            let edgeName = l.TensorGraph.MakeName(sprintf "Add_%s_%s" l.Name r.Name) 
            let op = add l.Head r.Head
            let node = Node(l.TensorGraph, op.Name, op.Op.[0], [l :> Edge; r:>Edge])
            new Matrix<'dim0, 'dim1, 't>(l.TensorGraph, edgeName, node, 0)
        
        static member (-)(l:Matrix<'dim0, 'dim1, 't>, r:Matrix<'dim0, 'dim1, 't>) = 
            let edgeName = l.TensorGraph.MakeName(sprintf "Sub_%s_%s" l.Name r.Name) 
            let op = sub l.Head r.Head
            let node = Node(l.TensorGraph, op.Name, op.Op.[0], [l :> Edge; r:>Edge])
            new Matrix<'dim0, 'dim1, 't>(l.TensorGraph, edgeName, node, 0)
      
        static member (*)(l:Matrix<'dim0, 'dim1, 't>, r:Matrix<'dim0, 'dim1, 't>) = 
            let edgeName = l.TensorGraph.MakeName(sprintf "Mul_%s_%s" l.Name r.Name) 
            let op = mul l.Head r.Head
            let node = Node(l.TensorGraph, op.Name, op.Op.[0], [l :> Edge; r:>Edge])
            new Matrix<'dim0, 'dim1, 't>(l.TensorGraph, edgeName, node, 0)

        static member (/)(l:Matrix<'dim0, 'dim1, 't>, r:Matrix<'dim0, 'dim1, 't>) = 
            let edgeName = l.TensorGraph.MakeName(sprintf "Div_%s_%s" l.Name r.Name) 
            let op = div l.Head r.Head
            let node = Node(l.TensorGraph, op.Name, op.Op.[0], [l :> Edge; r:>Edge])
            new Matrix<'dim0, 'dim1, 't>(l.TensorGraph, edgeName, node, 0)

    type Mat<'dim0, 'dim1, 't when 'dim0 :> Number and 'dim1 :> Number and 't:> ValueType and 't : struct  and 't: (new: unit -> 't) and 't :> IEquatable<'t> and 't :> IFormattable and 't :> IComparable> = Matrix<'dim0, 'dim1, 't>

    type Mat<'dim0, 'dim1 when 'dim0 :> Number and 'dim1 :> Number> = Mat<'dim0, 'dim1, float32>
