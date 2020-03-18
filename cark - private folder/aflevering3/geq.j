.method main
.args 3
.locals 3
.define a = 1
.define b = 2
.define i = 3
.define at = 4
.define bt = 5

	bipush 30
	istore i
	iload a
	iflt ANEG
	
	// the constant a is positive
	iload b
	iflt SAFE
	
	// b is positive
	
posLoop:	
	bipush 124
	iload i
	dup
	iflt true
	invokevirtual findbit
	iinc i, -1
	dup
	iload a
	iand
	istore at
	iload b
	iand
	istore bt
	iload at
	iload bt
	if_icmpeq posLoop
	
	iload at
	ifeq false
	goto true

false:
	bipush 0
	ireturn


true:
	bipush 1
	ireturn

ANEG: 
	iload b iflt ABNEG
	// b is positive
	goto SAFE

ABNEG:
	bipush 124	
	iload i
	dup
	iflt true
	invokevirtual findbit
	iinc i, -1
	dup
	iload a
	iand
	istore at
	iload b
	iand
	istore bt
	iload at
	iload bt
	if_icmpeq ABNEG

	iload at
	ifeq false
	goto true


SAFE:
	iload a 
	iload b
	isub
	iflt else
	bipush 1
	goto endif
else:
	bipush 0
endif:
	ireturn

.method findbit
.args 2
.locals 1 
.define x = 1
.define y = 2

	bipush 1
	istore y

loop:
	iload x
	ifeq finish
	iinc x, -1
	iload y
	dup
	iadd
	istore y
	goto loop


finish:
	iload y 
	ireturn
