.section .text      # specifices that we are in code

# .global directive makes a label visible to the linker
# so that it can be linked with the C program.
# When our C program calls any of these functions, 
# the processor starts executing the instruction from
# the corresponding label.


.global mygetpid
.global mygetppid

mygetpid:
    # we are now in the mygetpid function. We need to do the 
    # system call and then return using 'ret' instruction.
	movq $39, %rax
	syscall
	ret





mygetppid:
    # we are now in the mygetppid function. We need to do the 
    # system call and then return using 'ret' instruction.
	movq $110, %rax
	syscall
	ret


# To get the system call numbers you can see, e.g.,:
# https://blog.rchapman.org/posts/Linux_System_Call_Table_for_x86_64/

# to compile this program, the easiest way is to give them both to gcc:
# > gcc ca.c cs.s -o ca
