.data
path: .ascii "./testdir0"
path_end:

.global _start
.text

_start:
	movq $84, %rax
	movq $path, %rdi
	syscall

	movq $60, %rax
	xor %rdi, %rdi
	syscall
