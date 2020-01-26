#r ".\\..\\..\\src\\Providers\\Sylvester.Provider.Arithmetic\\src\\Sylvester.Provider.Arithmetic.Runtime\\bin\\Release\\netstandard2.0\\Sylvester.Provider.Arithmetic.Runtime.dll"
#r ".\\..\\..\\src\\Base\\Sylvester.Collections\\bin\\Debug\\netstandard2.0\\Sylvester.Collections.dll"
#r ".\\..\\..\\src\\Math\\Sylvester.AbstractAlgebra\\bin\\Debug\\netstandard2.0\\Sylvester.AbstractAlgebra.dll"

open Sylvester.Arithmetic
open Sylvester.Collections
open Sylvester.AbstractAlgebra


let Z = Set(fun (_:int) -> true)

let M = Monoid(Z, (+), 0)

let N = Monoid(Z, (+), 0)

let S = Morph(M, N, fun x -> 2 * x)