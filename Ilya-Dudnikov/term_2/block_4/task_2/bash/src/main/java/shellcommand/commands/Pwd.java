package shellcommand.commands;

import shellcommand.Command;

import java.nio.ByteBuffer;

public class Pwd extends Command {
	@Override
	public ByteBuffer run(String ... args) {
		return ByteBuffer.wrap((System.getenv("user.dir") + System.lineSeparator()).getBytes());
	}
}
